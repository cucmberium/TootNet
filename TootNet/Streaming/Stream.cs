using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using TootNet.Objects;

namespace TootNet.Streaming
{
    public enum StreamingType
    {
        User = 0,
        Tag = 1,
        Public = 2
    }

    public class StreamingObservable : IObservable<StreamingMessage>
    {
        public StreamingObservable(Tokens tokens, StreamingType type,
            IDictionary<string, object> parameters = null)
        {
            this._tokens = tokens;
            this._type = type;
            this._parameters = parameters;
        }

        private readonly Tokens _tokens;
        private readonly StreamingType _type;
        private readonly IDictionary<string, object> _parameters;

        public IDisposable Subscribe(IObserver<StreamingMessage> observer)
        {
            var streamingUrl = _tokens.Instance;
            var conn = new StreamingConnection();
            switch (_type)
            {
                case StreamingType.User:
                    conn.Start(observer, _tokens, "https://" + streamingUrl + "/api/v1/streaming/user");
                    break;
                case StreamingType.Tag:
                    conn.Start(observer, _tokens,
                        "https://" + streamingUrl + "/api/v1/streaming/hashtag" + "?tag=" +
                        _parameters["track"]);
                    break;
                case StreamingType.Public:
                    var publicStreamingUrl = "https://" + streamingUrl + "/api/v1/streaming/public";
                    if (_parameters.ContainsKey("local") && (bool)_parameters["local"])
                        publicStreamingUrl += "/local";

                    conn.Start(observer, _tokens, publicStreamingUrl);
                    break;
            }
            return conn;
        }
    }

    public class StreamingConnection : IDisposable
    {
        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();

        public async void Start(IObserver<StreamingMessage> observer, Tokens tokens, string url)
        {
            var token = this._cancel.Token;
            try
            {
                using (var client = new HttpClient())
                using (token.Register(client.Dispose))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokens.AccessToken);
                    using (var stream = await client.GetStreamAsync(url))
                    using (token.Register(stream.Dispose))
                    using (var reader = new StreamReader(stream))
                    using (token.Register(reader.Dispose))
                    {
                        string eventName = null;
                        while (!reader.EndOfStream)
                        {
                            var line = await reader.ReadLineAsync();
                            if (string.IsNullOrEmpty(line) || line.StartsWith(":"))
                            {
                                eventName = null;
                                continue;
                            }

                            if (line.StartsWith("event: "))
                            {
                                eventName = line.Substring("event: ".Length).Trim();
                            }
                            if (line.StartsWith("data: "))
                            {
                                var data = line.Substring("data: ".Length);
                                switch (eventName)
                                {
                                    case "update":
                                        var status = JsonConvert.DeserializeObject<Status>(data);
                                        observer.OnNext(new StreamingMessage(status));
                                        break;
                                    case "notification":
                                        var notification = JsonConvert.DeserializeObject<Notification>(data);
                                        observer.OnNext(new StreamingMessage(notification));
                                        break;
                                    case "delete":
                                        var statusId = int.Parse(data);
                                        observer.OnNext(new StreamingMessage(statusId));
                                        break;
                                }
                            }
                        }
                        observer.OnCompleted();
                    }
                }
            }
            catch (System.Exception e)
            {
                if (!token.IsCancellationRequested)
                {
                    observer.OnError(e);
                }
            }
        }

        public void Dispose()
        {
            try
            {
                _cancel.Cancel();
            }
            catch
            {
            }
        }
    }
}

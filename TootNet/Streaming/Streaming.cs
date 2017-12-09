using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using Newtonsoft.Json;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Streaming
{
    public enum StreamingType
    {
        User = 0,
        Hashtag = 1,
        Public = 2
    }

    public class StreamingApi : ApiBase
    {
        internal StreamingApi(Tokens e) : base(e) { }

        /// <summary>
        /// Streams messages for a hashtag timeline.
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> HashtagAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Hashtag, Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// Streams messages for a hashtag timeline.
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> HashtagAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Hashtag, parameters);
        }

        /// <summary>
        /// Streams messages for a hashtag timeline.
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> PublicAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Public, Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// Streams messages for a public timeline.
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> local (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> PublicAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Public, parameters);
        }

        /// <summary>
        /// Streams messages for a single user.
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> UserAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.User, Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// Streams messages for a single user.
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> UserAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.User, parameters);
        }
    }

    internal class StreamingObservable : IObservable<StreamingMessage>
    {
        public StreamingObservable(Tokens tokens, StreamingType type,
            IDictionary<string, object> parameters = null)
        {
            _tokens = tokens;
            _type = type;
            _parameters = parameters;
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
                case StreamingType.Hashtag:
                    if (!_parameters.ContainsKey("tag") || string.IsNullOrEmpty(_parameters["tag"].ToString()))
                        throw new ArgumentException("You must specify a hashtag");

                    conn.Start(observer, _tokens, "https://" + streamingUrl + "/api/v1/streaming/hashtag" + "?tag=" + _parameters["tag"]);
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

    internal class StreamingConnection : IDisposable
    {
        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();

        public async void Start(IObserver<StreamingMessage> observer, Tokens tokens, string url)
        {
            var token = _cancel.Token;
            try
            {
                using (var client = tokens.ConnectionOptions.GetHttpClient(tokens.AccessToken, false))
                using (token.Register(client.Dispose))
                {
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
                                        var statusId = long.Parse(data);
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
            _cancel.Cancel();
        }
    }
}

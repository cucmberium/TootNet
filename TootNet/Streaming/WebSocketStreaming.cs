using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Streaming
{
    public class WebSocketStreamingApi : ApiBase
    {
        internal WebSocketStreamingApi(Tokens e) : base(e) { }

        /// <summary>
        /// Watch your home timeline and notifications
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> UserAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.User, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="UserAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> UserAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.User, parameters);
        }

        /// <summary>
        /// Watch your notifications
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> UserNotificationAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.UserNotification, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="UserNotificationAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> UserNotificationAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.UserNotification, parameters);
        }

        /// <summary>
        /// Watch the federated timeline
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> PublicAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.Public, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PublicAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> PublicAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.Public, parameters);
        }

        /// <summary>
        /// Watch the local timeline
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> PublicLocalAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.PublicLocal, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PublicLocalAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> PublicLocalAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.PublicLocal, parameters);
        }

        /// <summary>
        /// Watch the remote statuses
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> only_media (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> PublicRemoteAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.PublicRemote, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PublicRemoteAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> PublicRemoteAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.PublicRemote, parameters);
        }

        /// <summary>
        /// Watch the public timeline for a hashtag
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> HashtagAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.Hashtag, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="HashtagAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> HashtagAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.Hashtag, parameters);
        }

        /// <summary>
        /// Watch the local timeline for a hashtag
        /// <para>Available parameters:</para>
        /// <para>- <c>string</c> tag (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> HashtagLocalAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.HashtagLocal, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="HashtagLocalAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> HashtagLocalAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.HashtagLocal, parameters);
        }

        /// <summary>
        /// Watch for list updates
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> list (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> ListAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.List, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="ListAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> ListAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.List, parameters);
        }

        /// <summary>
        /// Watch for direct messages
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> DirectAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.Direct, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="DirectAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> DirectAsObservable(IDictionary<string, object> parameters)
        {
            return new WebSocketStreamingObservable(Tokens, StreamingType.Direct, parameters);
        }
    }

    internal class WebSocketStreamingObservable : IObservable<StreamingMessage>
    {
        public WebSocketStreamingObservable(Tokens tokens, StreamingType type,
            IDictionary<string, object> parameters = null)
        {
            _tokens = tokens;
            _type = type;
            _parameters = parameters is null ? new Dictionary<string, object>() : new Dictionary<string, object>(parameters);
        }

        private readonly Tokens _tokens;
        private readonly StreamingType _type;
        private readonly Dictionary<string, object> _parameters;

        public IDisposable Subscribe(IObserver<StreamingMessage> observer)
        {
            var conn = new WebSocketStreamingConnection();

            var url = "wss://" + _tokens.Instance + "/api/v1/streaming";
            switch (_type)
            {
                case StreamingType.User:
                    _parameters["stream"] = "user";
                    break;
                case StreamingType.UserNotification:
                    _parameters["stream"] = "user:notification";
                    break;
                case StreamingType.Public:
                    if (_parameters.ContainsKey("only_media") && (bool)_parameters["only_media"])
                        _parameters["stream"] = "public:media";
                    else
                        _parameters["stream"] = "public";
                    break;
                case StreamingType.PublicLocal:
                    if (_parameters.ContainsKey("only_media") && (bool)_parameters["only_media"])
                        _parameters["stream"] = "public:local:media";
                    else
                        _parameters["stream"] = "public:local";
                    break;
                case StreamingType.PublicRemote:
                    if (_parameters.ContainsKey("only_media") && (bool)_parameters["only_media"])
                        _parameters["stream"] = "public:remote:media";
                    else
                        _parameters["stream"] = "public:remote";
                    break;
                case StreamingType.Hashtag:
                    if (!_parameters.ContainsKey("tag") || string.IsNullOrEmpty(_parameters["tag"].ToString()))
                        throw new ArgumentException("You must specify a tag");

                    _parameters["stream"] = "hashtag";
                    break;
                case StreamingType.HashtagLocal:
                    if (!_parameters.ContainsKey("tag") || string.IsNullOrEmpty(_parameters["tag"].ToString()))
                        throw new ArgumentException("You must specify a tag");

                    _parameters["stream"] = "hashtag";
                    break;
                case StreamingType.List:
                    if (!_parameters.ContainsKey("list") || string.IsNullOrEmpty(_parameters["list"].ToString()))
                        throw new ArgumentException("You must specify a list");

                    _parameters["stream"] = "list";
                    break;
                case StreamingType.Direct:
                    _parameters["stream"] = "direct";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _parameters["access_token"] = _tokens.AccessToken;
            if (_parameters.ContainsKey("only_media"))
            {
                _parameters.Remove("only_media");
            }

            conn.Start(observer, _tokens, url, _parameters);
            return conn;
        }
    }

    internal class WebSocketStreamingConnection : IDisposable
    {
        private const int BufferSize = 1024;

        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();

        public async void Start(IObserver<StreamingMessage> observer, Tokens tokens, string url, IDictionary<string, object> param)
        {
            var token = _cancel.Token;
            try
            {
                using (var client = new ClientWebSocket())
                using (token.Register(client.Dispose))
                {
                    await client.ConnectAsync(new Uri(url), token);

                    var buffer = new byte[BufferSize];
                    using (var memoryStream = new MemoryStream())
                    using (token.Register(memoryStream.Dispose))
                    {
                        while (client.State == WebSocketState.Open)
                        {
                            var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), token);

                            if (result.MessageType == WebSocketMessageType.Close)
                            {
                                observer.OnCompleted();
                                return;
                            }

                            memoryStream.Write(buffer, 0, result.Count);
                            if (!result.EndOfMessage)
                                continue;

                            var message = Encoding.UTF8.GetString(memoryStream.ToArray());
                            var ev = JsonConvert.DeserializeObject<StreamingEvent>(message);
                            switch (ev.Event)
                            {
                                case "update":
                                    var status = JsonConvert.DeserializeObject<Status>(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Status, status));
                                    break;
                                case "delete":
                                    var deletedStatusId = long.Parse(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.StatusDelete, deletedStatusId));
                                    break;
                                case "notification":
                                    var notification = JsonConvert.DeserializeObject<Notification>(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Notification, notification));
                                    break;
                                case "filters_changed":
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.FiltersChanged));
                                    break;
                                case "conversation":
                                    var conversation = JsonConvert.DeserializeObject<Conversation>(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Conversation, conversation));
                                    break;
                                case "announcement":
                                    var announcement = JsonConvert.DeserializeObject<Announcement>(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Announcement, announcement));
                                    break;
                                case "announcement.reaction":
                                    var announcementReaction = JsonConvert.DeserializeObject<Reaction>(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.AnnouncementReaction, announcementReaction));
                                    break;
                                case "announcement.delete":
                                    var deletedAnnouncementId = long.Parse(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.AnnouncementDelete, deletedAnnouncementId));
                                    break;
                                case "status.update":
                                    var updatedStatus = JsonConvert.DeserializeObject<Status>(ev.Payload);
                                    observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.StatusUpdate, updatedStatus));
                                    break;
                                case "encrypted_message":
                                    break;
                            }

                            memoryStream.SetLength(0);
                        }
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

    internal class StreamingEvent
    {
        [JsonProperty("stream")]
        public IEnumerable<string> Stream { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}

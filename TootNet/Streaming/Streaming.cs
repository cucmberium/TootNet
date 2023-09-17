using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Streaming
{
    public enum StreamingType
    {
        User = 0,
        UserNotification = 1,
        Public = 2,
        PublicLocal = 3,
        PublicRemote = 4,
        Hashtag = 5,
        HashtagLocal = 6,
        List = 7,
        Direct = 8
    }

    public class StreamingApi : ApiBase
    {
        internal StreamingApi(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Check if the server is alive</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the string object.</para>
        /// </returns>
        public Task<string> CheckAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<string>(MethodType.Get, "streaming/health", Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="CheckAsync(Expression{Func{string, object}}[])"/>
        public Task<string> CheckAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<string>(MethodType.Get, "streaming/health", parameters);
        }

        /// <summary>
        /// Watch your home timeline and notifications
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The stream messages.</returns>
        public IObservable<StreamingMessage> UserAsObservable(params Expression<Func<string, object>>[] parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.User, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="UserAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> UserAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.User, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.UserNotification, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="UserNotificationAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> UserNotificationAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.UserNotification, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.Public, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PublicAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> PublicAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Public, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.PublicLocal, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PublicLocalAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> PublicLocalAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.PublicLocal, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.PublicRemote, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="PublicRemoteAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> PublicRemoteAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.PublicRemote, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.Hashtag, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="HashtagAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> HashtagAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Hashtag, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.HashtagLocal, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="HashtagLocalAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> HashtagLocalAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.HashtagLocal, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.List, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="ListAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> ListAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.List, parameters);
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
            return new StreamingObservable(Tokens, StreamingType.Direct, Utils.ExpressionToDictionary(parameters));
        }

        /// <inheritdoc cref="DirectAsObservable(Expression{Func{string, object}}[])"/>
        public IObservable<StreamingMessage> DirectAsObservable(IDictionary<string, object> parameters)
        {
            return new StreamingObservable(Tokens, StreamingType.Direct, parameters);
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
            var conn = new StreamingConnection();

            var url = "https://" + _tokens.Instance + "/api/v1/streaming";
            switch (_type)
            {
                case StreamingType.User:
                    url += "/user";
                    break;
                case StreamingType.UserNotification:
                    url += "/user/notification";
                    break;
                case StreamingType.Public:
                    url += "/public";
                    break;
                case StreamingType.PublicLocal:
                    url += "/public/local";
                    break;
                case StreamingType.PublicRemote:
                    url += "/public/remote";
                    break;
                case StreamingType.Hashtag:
                    if (!_parameters.ContainsKey("tag") || string.IsNullOrEmpty(_parameters["tag"].ToString()))
                        throw new ArgumentException("You must specify a tag");

                    url += "/hashtag";
                    break;
                case StreamingType.HashtagLocal:
                    if (!_parameters.ContainsKey("tag") || string.IsNullOrEmpty(_parameters["tag"].ToString()))
                        throw new ArgumentException("You must specify a tag");

                    url += "/hashtag/local";
                    break;
                case StreamingType.List:
                    if (!_parameters.ContainsKey("list") || string.IsNullOrEmpty(_parameters["list"].ToString()))
                        throw new ArgumentException("You must specify a list");

                    url += "/list";
                    break;
                case StreamingType.Direct:
                    url += "/direct";
                    break;
            }

            url = _parameters == null ? url : Utils.CreateUrlParameter(url, _parameters);

            conn.Start(observer, _tokens, url);
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
                    using (var reader = new StreamReader(stream, Encoding.UTF8, true, 16384))
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
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Status, status));
                                        break;
                                    case "delete":
                                        var deletedStatusId = long.Parse(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.StatusDelete, deletedStatusId));
                                        break;
                                    case "notification":
                                        var notification = JsonConvert.DeserializeObject<Notification>(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Notification, notification));
                                        break;
                                    case "filters_changed":
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.FiltersChanged));
                                        break;
                                    case "conversation":
                                        var conversation = JsonConvert.DeserializeObject<Conversation>(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Conversation, conversation));
                                        break;
                                    case "announcement":
                                        var announcement = JsonConvert.DeserializeObject<Announcement>(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.Announcement, announcement));
                                        break;
                                    case "announcement.reaction":
                                        var announcementReaction = JsonConvert.DeserializeObject<Reaction>(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.AnnouncementReaction, announcementReaction));
                                        break;
                                    case "announcement.delete":
                                        var deletedAnnouncementId = long.Parse(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.AnnouncementDelete, deletedAnnouncementId));
                                        break;
                                    case "status.update":
                                        var updatedStatus = JsonConvert.DeserializeObject<Status>(data);
                                        observer.OnNext(new StreamingMessage(StreamingMessage.MessageType.StatusUpdate, updatedStatus));
                                        break;
                                    case "encrypted_message":
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

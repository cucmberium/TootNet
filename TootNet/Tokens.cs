using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;
using TootNet.Streaming;

namespace TootNet
{
    public class Tokens : TokensBase
    {
        public Tokens(string instance, string accessToken, string clientId = null, string clientSecret = null)
        {
            Instance = instance;
            AccessToken = accessToken;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Accounts
        /// </summary>
        public Rest.Accounts Accounts => new Rest.Accounts(this);

        /// <summary>
        /// Announcements
        /// </summary>
        public Rest.Announcements Announcements => new Rest.Announcements(this);

        /// <summary>
        /// Apps
        /// </summary>
        public Rest.Apps Apps => new Rest.Apps(this);

        /// <summary>
        /// Blocks
        /// </summary>
        public Rest.Blocks Blocks => new Rest.Blocks(this);

        /// <summary>
        /// Bookmarks
        /// </summary>
        public Rest.Bookmarks Bookmarks => new Rest.Bookmarks(this);

        /// <summary>
        /// Conversations
        /// </summary>
        public Rest.Conversations Conversations => new Rest.Conversations(this);

        /// <summary>
        /// CustomEmojis
        /// </summary>
        public Rest.CustomEmojis CustomEmojis => new Rest.CustomEmojis(this);

        /// <summary>
        /// Directory
        /// </summary>
        public Rest.Directory Directory => new Rest.Directory(this);

        /// <summary>
        /// DomainBlocks
        /// </summary>
        public Rest.DomainBlocks DomainBlocks => new Rest.DomainBlocks(this);

        /// <summary>
        /// Endorsements
        /// </summary>
        public Rest.Endorsements Endorsements => new Rest.Endorsements(this);


        /// <summary>
        /// Favorites
        /// </summary>
        public Rest.Favourites Favourites => new Rest.Favourites(this);

        /// <summary>
        /// FeaturedTags
        /// </summary>
        public Rest.FeaturedTags FeaturedTags => new Rest.FeaturedTags(this);

        /// <summary>
        /// Filters
        /// </summary>
        public Rest.Filters Filters => new Rest.Filters(this);

        /// <summary>
        /// FollowRequests
        /// </summary>
        public Rest.FollowRequests FollowRequests => new Rest.FollowRequests(this);

        /// <summary>
        /// GroupedNotifications
        /// </summary>
        public Rest.GroupedNotifications GroupedNotifications => new Rest.GroupedNotifications(this);

        /// <summary>
        /// Instances (alias of Instance)
        /// </summary>
        public Rest.Instance Instances => new Rest.Instance(this);

        /// <summary>
        /// Lists
        /// </summary>
        public Rest.Lists Lists => new Rest.Lists(this);

        /// <summary>
        /// Markers
        /// </summary>
        public Rest.Markers Markers => new Rest.Markers(this);

        /// <summary>
        /// Media
        /// </summary>
        public Rest.Media Media => new Rest.Media(this);

        /// <summary>
        /// Mutes
        /// </summary>
        public Rest.Mutes Mutes => new Rest.Mutes(this);

        /// <summary>
        /// Notifications
        /// </summary>
        public Rest.Notifications Notifications => new Rest.Notifications(this);

        /// <summary>
        /// OEmbed
        /// </summary>
        public Rest.OEmbed OEmbed => new Rest.OEmbed(this);

        /// <summary>
        /// Polls
        /// </summary>
        public Rest.Polls Polls => new Rest.Polls(this);

        /// <summary>
        /// Preferences
        /// </summary>
        public Rest.Preferences Preferences => new Rest.Preferences(this);

        /// <summary>
        /// Profile
        /// </summary>
        public Rest.Profile Profile => new Rest.Profile(this);

        /// <summary>
        /// Reports
        /// </summary>
        public Rest.Reports Reports => new Rest.Reports(this);

        /// <summary>
        /// ScheduledStatuses
        /// </summary>
        public Rest.ScheduledStatuses ScheduledStatuses => new Rest.ScheduledStatuses(this);

        /// <summary>
        /// Search
        /// </summary>
        public Rest.Search Search => new Rest.Search(this);

        /// <summary>
        /// Statuses
        /// </summary>
        public Rest.Statuses Statuses => new Rest.Statuses(this);

        /// <summary>
        /// Suggestions
        /// </summary>
        public Rest.Suggestions Suggestions => new Rest.Suggestions(this);

        /// <summary>
        /// Tags
        /// </summary>
        public Rest.Tags Tags => new Rest.Tags(this);

        /// <summary>
        /// Timelines
        /// </summary>
        public Rest.Timelines Timelines => new Rest.Timelines(this);

        /// <summary>
        /// Trends
        /// </summary>
        public Rest.Trends Trends => new Rest.Trends(this);

        /// <summary>
        /// Streaming
        /// </summary>
        public StreamingApi Streaming => new StreamingApi(this);

        /// <summary>
        /// Streaming w/ WebSocket
        /// </summary>
        public WebSocketStreamingApi WebSocketStreaming => new WebSocketStreamingApi(this);

        /// <summary>
        /// <para>Send request to target uri.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Relative path of accessing uri.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public async Task<AsyncResponse> SendRequestAsync(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            using (var httpClient = ConnectionOptions.GetHttpClient(AccessToken))
            {
                switch (type)
                {
                    case MethodType.Get:
                        return await Request.HttpGetAsync(httpClient, uri, param, headers);
                    case MethodType.Post:
                        return await Request.HttpPostAsync(httpClient, uri, param, headers);
                    case MethodType.Delete:
                        return await Request.HttpDeleteAsync(httpClient, uri, param, headers);
                    case MethodType.Patch:
                        return await Request.HttpPatchAsync(httpClient, uri, param, headers);
                    case MethodType.Put:
                        return await Request.HttpPutAsync(httpClient, uri, param, headers);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <param name="useApiPath">Use api path.</param>
        /// <param name="apiVersion">Version of api.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task<T> AccessApiAsync<T>(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1") where T : class
        {
            return AccessApiAsyncImpl<T>(type, uri, param, headers, useApiPath, apiVersion);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="reserved">Reserved parameter (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <param name="useApiPath">Use api path.</param>
        /// <param name="apiVersion">Version of api.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task<T> AccessParameterReservedApiAsync<T>(MethodType type, string uri, string reserved, IDictionary<string, object> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1") where T : class
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            var list = param.ToList();
            var kvp = Utils.GetReservedParameter(list, reserved);
            list.Remove(kvp);
            return AccessApiAsyncImpl<T>(type, uri.Replace($"{{{reserved}}}", kvp.Value.ToString()), list, headers, useApiPath, apiVersion);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="reserved">Reserved parameter (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <param name="useApiPath">Use api path.</param>
        /// <param name="apiVersion">Version of api.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task<T> AccessParameterReservedApiAsync<T>(MethodType type, string uri, IEnumerable<string> reserved, IDictionary<string, object> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1") where T : class
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));

            var list = param.ToList();

            var replacedUri = uri;
            foreach (var res in reserved)
            {
                var kvp = Utils.GetReservedParameter(list, res);
                list.Remove(kvp);
                replacedUri = replacedUri.Replace($"{{{reserved}}}", kvp.Value.ToString());
            }

            return AccessApiAsyncImpl<T>(type, replacedUri, list, headers, useApiPath, apiVersion);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <param name="useApiPath">Use api path.</param>
        /// <param name="apiVersion">Version of api.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task AccessApiAsync(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1")
        {
            return AccessApiAsyncImpl(type, uri, param, headers, useApiPath, apiVersion);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="reserved">Reserved parameter (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <param name="useApiPath">Use api path.</param>
        /// <param name="apiVersion">Version of api.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task AccessParameterReservedApiAsync(MethodType type, string uri, string reserved, IDictionary<string, object> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1")
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            var list = param.ToList();
            var kvp = Utils.GetReservedParameter(list, reserved);
            list.Remove(kvp);
            return AccessApiAsyncImpl(type, uri.Replace($"{{{reserved}}}", kvp.Value.ToString()), list, headers, useApiPath, apiVersion);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="reserved">Reserved parameters (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <param name="useApiPath">Use api path.</param>
        /// <param name="apiVersion">Version of api.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task AccessParameterReservedApiAsync(MethodType type, string uri, IEnumerable<string> reserved, IDictionary<string, object> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1")
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));

            var list = param.ToList();

            var replacedUri = uri;
            foreach (var res in reserved)
            {
                var kvp = Utils.GetReservedParameter(list, res);
                list.Remove(kvp);
                replacedUri = replacedUri.Replace($"{{{reserved}}}", kvp.Value.ToString());
            }
            
            return AccessApiAsyncImpl(type, replacedUri, list, headers, useApiPath, apiVersion);
        }

        private async Task<T> AccessApiAsyncImpl<T>(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1") where T : class
        {
            using (var response = await SendRequestAsync(type, ConstructUri(uri, useApiPath, apiVersion), FormatParameters(param), headers).ConfigureAwait(false))
            {
                var json = await response.GetResponseStringAsync();
                var obj = Converter.Convert<T>(json);

                if (obj is IBaseObject baseObject)
                    baseObject.RawJson = json;

                if (obj is ILinked linked)
                {
                    if (response.Source.Headers.Any(x => x.Key.ToLower() == "link"))
                    {
                        var linkInfo = response.Source.Headers.First(x => x.Key.ToLower() == "link").Value.First();
                        foreach (var match in linkInfo.Split(',').Select(x =>
                            Regex.Match(x, "<http.+[?&](max_id|since_id)=(\\d+).*>;\\s*rel=\".{4}\"")))
                        {
                            if (match.Groups[1].ToString() == "max_id")
                                linked.MaxId = long.Parse(match.Groups[2].ToString());
                            else if (match.Groups[1].ToString() == "since_id")
                                linked.SinceId = long.Parse(match.Groups[2].ToString());
                        }
                    }
                }

                return obj;
            }
        }

        private async Task AccessApiAsyncImpl(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null, bool useApiPath = true, string apiVersion = "v1")
        {
            using (var response = await SendRequestAsync(type, ConstructUri(uri, useApiPath, apiVersion), FormatParameters(param), headers).ConfigureAwait(false))
            {
                var json = await response.GetResponseStringAsync();
                if (!string.IsNullOrWhiteSpace(json))
                    Converter.ConvertError(json);
            }
        }

        private IEnumerable<KeyValuePair<string, object>> FormatParameters(IEnumerable<KeyValuePair<string, object>> param)
        {
            if (param == null)
                yield break;

            foreach (var p in param)
            {
                if (p.Value == null)
                    continue;

                if (p.Value is IEnumerable v && !(p.Value is string))
                {
                    foreach (var x in v.Cast<object>().Select(y => y.ToString()))
                        yield return new KeyValuePair<string, object>(p.Key + "[]", x);
                }
                else
                {
                    yield return p;
                }
            }
        }
    }
}

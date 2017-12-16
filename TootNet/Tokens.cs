using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using TootNet.Internal;
using TootNet.Objects;
using TootNet.Rest;
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
        public Accounts Accounts => new Accounts(this);
        
        /// <summary>
        /// Blocks
        /// </summary>
        public Blocks Blocks => new Blocks(this);

        /// <summary>
        /// DomainBlocks
        /// </summary>
        public DomainBlocks DomainBlocks => new DomainBlocks(this);

        /// <summary>
        /// Favorites
        /// </summary>
        public Favourites Favourites => new Favourites(this);

        /// <summary>
        /// FollowRequests
        /// </summary>
        public FollowRequests FollowRequests => new FollowRequests(this);

        /// <summary>
        /// Follows
        /// </summary>
        public Follows Follows => new Follows(this);

        /// <summary>
        /// Instances
        /// </summary>
        public Instances Instances => new Instances(this);

        /// <summary>
        /// Media
        /// </summary>
        public Media Media => new Media(this);

        /// <summary>
        /// Mutes
        /// </summary>
        public Mutes Mutes => new Mutes(this);

        /// <summary>
        /// Notifications
        /// </summary>
        public Notifications Notifications => new Notifications(this);

        /// <summary>
        /// Reports
        /// </summary>
        public Reports Reports => new Reports(this);

        /// <summary>
        /// Search
        /// </summary>
        public Search Search => new Search(this);

        /// <summary>
        /// Statuses
        /// </summary>
        public Statuses Statuses => new Statuses(this);

        /// <summary>
        /// Timelines
        /// </summary>
        public Timelines Timelines => new Timelines(this);

        /// <summary>
        /// Streaming
        /// </summary>
        public StreamingApi Streaming => new StreamingApi(this);

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
                }
            }

            return null;
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task<T> AccessApiAsync<T>(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null) where T : class
        {
            return AccessApiAsyncImpl<T>(type, uri, param, headers);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="reserved">Reserved parameter (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task<T> AccessParameterReservedApiAsync<T>(MethodType type, string uri, string reserved, IDictionary<string, object> param = null, IDictionary<string, string> headers = null) where T : class
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            var list = param.ToList();
            var kvp = Utils.GetReservedParameter(list, reserved);
            list.Remove(kvp);
            return AccessApiAsyncImpl<T>(type, uri.Replace(string.Format("{{{0}}}", reserved), kvp.Value.ToString()), list, headers);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task AccessApiAsync(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            return AccessApiAsyncImpl(type, uri, param, headers);
        }

        /// <summary>
        /// <para>Access mastodon api targeted in uri field.</para>
        /// </summary>
        /// <param name="type">Method type of request.</param>
        /// <param name="uri">Uri to access (relative path from API).</param>
        /// <param name="reserved">Reserved parameter (relative path from API).</param>
        /// <param name="param">The parameter.</param>
        /// <param name="headers">Headers of request.</param>
        /// <returns>
        /// <para>AsyncResponse of request.</para>
        /// </returns>
        public Task AccessParameterReservedApiAsync(MethodType type, string uri, string reserved, IDictionary<string, object> param = null, IDictionary<string, string> headers = null)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            var list = param.ToList();
            var kvp = Utils.GetReservedParameter(list, reserved);
            list.Remove(kvp);
            return AccessApiAsyncImpl(type, uri.Replace(string.Format("{{{0}}}", reserved), kvp.Value.ToString()), list, headers);
        }

        private async Task<T> AccessApiAsyncImpl<T>(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null) where T : class
        {
            using (var response = await SendRequestAsync(type, ConstructUri(uri), FormatParameters(param), headers).ConfigureAwait(false))
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

        private async Task AccessApiAsyncImpl(MethodType type, string uri, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            await SendRequestAsync(type, ConstructUri(uri), FormatParameters(param), headers).ConfigureAwait(false);
        }

        private IEnumerable<KeyValuePair<string, object>> FormatParameters(IEnumerable<KeyValuePair<string, object>> param)
        {
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

using System.Collections.Generic;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Rest;

namespace TootNet
{
    public class Tokens
    {
        public Tokens(string instance, string accessToken, string clientId = null, string clientSecret = null)
        {
            ConnectionOptions = new Connection();
            Instance = instance;
            AccessToken = accessToken;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Gets or sets the options of the connection.
        /// </summary>
        public Connection ConnectionOptions { get; set; }

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Accounts
        /// </summary>
        public Accounts Accounts => new Accounts(this);

        /// <summary>
        /// Apps
        /// </summary>
        public Apps Apps => new Apps(this);

        /// <summary>
        /// Blocks
        /// </summary>
        public Blocks Blocks => new Blocks(this);

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
        /// <param>Available parameters:</param>
        /// <param>- <c>MethodType</c> type (required) [ GET, POST, DELETE ]</param>
        /// <param>- <c>string</c> url (required)</param>
        /// <param>- <c>IEnumerable</c> param (optional)</param>
        /// <param>- <c>IDictionary</c> header (optional)</param>
        /// </summary>
        /// <returns>AsyncResponse.</returns>
        public async Task<AsyncResponse> SendRequestAsync(MethodType type, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            using (var httpClient = ConnectionOptions.GetHttpClient())
            {
                switch (type)
                {
                    case MethodType.GET:
                        return await Request.HttpGetAsync(httpClient, url, param, headers);
                    case MethodType.POST:
                        return await Request.HttpPostAsync(httpClient, url, param, headers);
                    case MethodType.DELETE:
                        return await Request.HttpDeleteAsync(httpClient, url, param, headers);
                }
            }

            return null;
        }
        
        private async Task<T> AccessApiAsync<T>(MethodType type, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null) where T : class
        {
            using (var response = await SendRequestAsync(type, url, param, headers).ConfigureAwait(false))
            {
                var json = await response.GetResponseStringAsync();
                var obj = Converter.Convert<T>(json);

                return obj;
            }
        }

        private string ConstructUri(string route)
        {
            return "https://" + Instance + route;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet
{
    [Flags]
    public enum Scope
    {
        Read = 1,
        Write = 2,
        Read_Accounts = 4,
        Read_Blocks = 8,
        Read_Bookmarks = 16,
        Read_Favourites = 32,
        Read_Filters = 64,
        Read_Follows = 128,
        Read_Lists = 256,
        Read_Mutes = 512,
        Read_Notifications = 1024,
        Read_Search = 2048,
        Read_Statuses = 4096,
        Write_Accounts = 8192,
        Write_Blocks = 16384,
        Write_Bookmarks = 32768,
        Write_Conversations = 65536,
        Write_Favourites = 131072,
        Write_Filters = 262144,
        Write_Follows = 524288,
        Write_Lists = 1048576,
        Write_Media = 2097152,
        Write_Mutes = 4194304,
        Write_Notifications = 8388608,
        Write_Reports = 16777216,
        Write_Statuses = 33554432,
    }
    
    public class Authorize : TokensBase
    {
        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        public Scope Scope { get; private set; }

        /// <summary>
        /// Registering an application.
        /// </summary>
        /// <param name="instance">Instance to connect.</param>
        /// <param name="appName">Name of your application.</param>
        /// <param name="scope">The rights needed by your application.</param>
        /// <param name="website">URL to the homepage of your app.</param>
        /// <param name="redirectUri">Redirect uri.</param>
        /// <returns></returns>
        public async Task CreateApp(string instance, string appName, Scope scope, string website = null, string redirectUri = "urn:ietf:wg:oauth:2.0:oob")
        {
            Instance = instance;
            Scope = scope;

            var param = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_name", appName),
                new KeyValuePair<string, object>("scopes", ConstructScope(scope)),
                new KeyValuePair<string, object>("redirect_uris", redirectUri),
            };
            if (!string.IsNullOrEmpty(website))
                param.Add(new KeyValuePair<string, object>("website", website));
            
            var httpClient = ConnectionOptions.GetHttpClient();
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("apps"), param).ConfigureAwait(false);
            var app = Converter.Convert<App>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            ClientId = app.ClientId;
            ClientSecret = app.ClientSecret;
        }

        /// <summary>
        /// Authorize with code.
        /// </summary>
        /// <param name="code">Code displayed in browser.</param>
        /// <param name="redirectUri">Redirect uri.</param>
        /// <returns>Tokens to access mastodon api.</returns>
        public async Task<Tokens> AuthorizeWithCode(string code, string redirectUri = "urn:ietf:wg:oauth:2.0:oob")
        {
            var param = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", ClientId),
                new KeyValuePair<string, object>("client_secret", ClientSecret),
                new KeyValuePair<string, object>("grant_type", "authorization_code"),
                new KeyValuePair<string, object>("redirect_uri", redirectUri),
                new KeyValuePair<string, object>("code", code),
            };

            var httpClient = ConnectionOptions.GetHttpClient();
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("/oauth/token", false), param).ConfigureAwait(false);
            var auth = Converter.Convert<Token>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            AccessToken = auth.AccessToken;
            return new Tokens(Instance, AccessToken, ClientId, ClientSecret);
        }

        /// <summary>
        /// Authorize with app-level access.
        /// </summary>
        /// <param name="redirectUri">Redirect uri.</param>
        /// <returns>Tokens to access mastodon api.</returns>
        public async Task<Tokens> AuthorizeWithClientCredentials(string redirectUri = "urn:ietf:wg:oauth:2.0:oob")
        {
            var param = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", ClientId),
                new KeyValuePair<string, object>("client_secret", ClientSecret),
                new KeyValuePair<string, object>("grant_type", "client_credentials"),
                new KeyValuePair<string, object>("redirect_uri", redirectUri),
            };

            var httpClient = ConnectionOptions.GetHttpClient();
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("/oauth/token", false), param).ConfigureAwait(false);
            var auth = Converter.Convert<Token>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            AccessToken = auth.AccessToken;
            return new Tokens(Instance, AccessToken, ClientId, ClientSecret);
        }

        /// <summary>
        /// Revoke token.
        /// </summary>
        /// <param name="token">Token to acess mastodon api.</param>
        /// <returns></returns>
        public async Task RevokeToken(string token)
        {
            var param = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", ClientId),
                new KeyValuePair<string, object>("client_secret", ClientSecret),
                new KeyValuePair<string, object>("token", token),
            };

            var httpClient = ConnectionOptions.GetHttpClient();
            await Request.HttpPostAsync(httpClient, ConstructUri("/oauth/revoke", false), param).ConfigureAwait(false);
        }

        /// <summary>
        /// Get authorize uri need to authorize in browser.
        /// </summary>
        /// <param name="redirectUri">Redirect uri.</param>
        /// <returns>Authorize uri.</returns>
        public string GetAuthorizeUri(string redirectUri = "urn:ietf:wg:oauth:2.0:oob")
        {
            return $"https://{Instance}/oauth/authorize?" +
                   $"response_type=code&" +
                   $"client_id={ClientId}&" +
                   $"scope={WebUtility.UrlEncode(ConstructScope(Scope))}&" +
                   $"redirect_uri={redirectUri}";
        }

        private string ConstructScope(Scope scope)
        {
            return string.Join(" ", Enum.GetValues(typeof(Scope)).Cast<Scope>().Where(x => (scope & x) == x).Select(x => x.ToString().ToLower().Replace("_", ":")));
        }
    }

    internal class App : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("vapid_key")]
        public string VapidKey { get; set; }
    }
}

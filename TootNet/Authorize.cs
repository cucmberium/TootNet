using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet
{
    [Flags]
    public enum Scope
    {
        Read = 1,
        Write = 2,
        Follow = 4
    }

    public class RegistApp
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }

    public class Auth
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }

    public class Authorize
    {
        public Authorize()
        {
            ConnectionOptions = new Connection();
        }

        /// <summary>
        /// Gets or sets the options of the connection.
        /// </summary>
        public Connection ConnectionOptions { get; set; }

        /// <summary>
        /// Gets or sets the Instance.
        /// </summary>
        public string Instance { get; private set; }

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; private set; }

        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        public Scope Scope { get; private set; }

        /// <summary>
        /// Registering an application
        /// </summary>
        /// <param name="instance">Instance to connect</param>
        /// <param name="appName">Name of your application</param>
        /// <param name="scope">The rights needed by your application</param>
        /// <param name="website">URL to the homepage of your app (optional)</param>
        /// <param name="redirectUri">Redirect url (optional)</param>
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
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("/api/v1/apps"), param).ConfigureAwait(false);
            var app = Converter.Convert<RegistApp>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            ClientId = app.ClientId;
            ClientSecret = app.ClientSecret;
        }

        /// <summary>
        /// Authorize with email and password
        /// </summary>
        /// <param name="email">Email of account</param>
        /// <param name="password">Password of account</param>
        /// <returns>Tokens to access mastodon api</returns>
        public async Task<Tokens> AuthorizeWithEmail(string email, string password)
        {
            var param = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", ClientId),
                new KeyValuePair<string, object>("client_secret", ClientSecret),
                new KeyValuePair<string, object>("grant_type", "password"),
                new KeyValuePair<string, object>("username", email),
                new KeyValuePair<string, object>("password", password),
                new KeyValuePair<string, object>("scope", ConstructScope(Scope)),
            };

            var httpClient = ConnectionOptions.GetHttpClient();
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("/oauth/token"), param).ConfigureAwait(false);
            var auth = Converter.Convert<Auth>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            AccessToken = auth.AccessToken;
            return new Tokens(Instance, AccessToken, ClientId, ClientSecret);
        }

        /// <summary>
        /// Authorize with code
        /// </summary>
        /// <param name="code">Code displayed in browser</param>
        /// <param name="redirectUri">Redirect url (optional)</param>
        /// <returns>Tokens to access mastodon api</returns>
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
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("/oauth/token"), param).ConfigureAwait(false);
            var auth = Converter.Convert<Auth>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            AccessToken = auth.AccessToken;
            return new Tokens(Instance, AccessToken, ClientId, ClientSecret);
        }

        /// <summary>
        /// Get authorize url need to authorize in browser
        /// </summary>
        /// <param name="redirectUri">Redirect url (optional)</param>
        /// <returns>Authorize url</returns>
        public string GetAuthorizeUrl(string redirectUri = null)
        {
            return $"https://{Instance}/oauth/authorize?" +
                   $"response_type=code&" +
                   $"client_id={ClientId}&" +
                   $"scope={WebUtility.UrlEncode(ConstructScope(Scope))}&" +
                   $"redirect_uri={redirectUri}";
        }

        private string ConstructUri(string route)
        {
            return "https://" + Instance + route;
        }

        private string ConstructScope(Scope scope)
        {
            return string.Join(" ", Enum.GetValues(typeof(Scope)).Cast<Scope>().Where(x => (scope & x) == x).Select(x => x.ToString().ToLower()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet
{
    [Flags]
    public enum Scope
    {
        Read = 1,
        Write = 2,
        Follow = 4
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
        /// Authorize with email and password.
        /// </summary>
        /// <param name="email">Email of account.</param>
        /// <param name="password">Password of account.</param>
        /// <returns>Tokens to access mastodon api.</returns>
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
            var asyncResponse = await Request.HttpPostAsync(httpClient, ConstructUri("/oauth/token", false), param).ConfigureAwait(false);
            var auth = Converter.Convert<Token>(await asyncResponse.GetResponseStringAsync().ConfigureAwait(false));

            AccessToken = auth.AccessToken;
            return new Tokens(Instance, AccessToken, ClientId, ClientSecret);
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
            return string.Join(" ", Enum.GetValues(typeof(Scope)).Cast<Scope>().Where(x => (scope & x) == x).Select(x => x.ToString().ToLower()));
        }
    }
}

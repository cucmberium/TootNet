using System;
using System.Collections.Generic;
using System.Text;

namespace TootNet.Internal
{
    public class TokensBase
    {
        internal TokensBase()
        {
            ConnectionOptions = new Connection();
            ApiPath = "/api/v1/";
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
        /// Gets or sets the api path.
        /// </summary>
        public string ApiPath { get; set; }

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

        protected string ConstructUri(string route)
        {
            return "https://" + Instance + ApiPath + route;
        }
    }
}

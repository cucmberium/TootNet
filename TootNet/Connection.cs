using System.Net;
using System.Net.Http;

namespace TootNet
{
    public class Connection
    {
        /// <summary>
        /// Gets or sets the value of the User-agent HTTP header.
        /// </summary>
        public string UserAgent { get; set; } = "TootNet";

        /// <summary>
        /// Gets or sets a value that indicates whether the handler uses a proxy for requests.
        /// </summary>
        public bool UseProxy { get; set; } = true;

        internal HttpClient GetHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseProxy = UseProxy,
                AutomaticDecompression = DecompressionMethods.GZip
            };

            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            return httpClient;
        }
    }
}

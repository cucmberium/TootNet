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

        internal HttpClient GetHttpClient(string accessToken = null, bool decompression = true)
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseProxy = false,
                AutomaticDecompression = decompression ? DecompressionMethods.GZip : DecompressionMethods.None
            };

            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            if (!string.IsNullOrWhiteSpace(accessToken))
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            return httpClient;
        }
    }
}

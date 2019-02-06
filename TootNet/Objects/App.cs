using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class App : BaseObject
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}

using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class OEmbedMetadata : BaseObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("provider_url")]
        public string ProviderUrl { get; set; }

        [JsonProperty("cache_age")]
        public int CacheAge { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }
}

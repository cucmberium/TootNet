using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Card : BaseObject
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("provider_url")]
        public string ProviderUrl { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }
}

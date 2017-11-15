using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Emoji : BaseObject
    {
        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

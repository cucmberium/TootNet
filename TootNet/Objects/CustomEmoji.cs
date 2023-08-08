using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class CustomEmoji : BaseObject
    {
        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }

        [JsonProperty("visible_in_picker")]
        public bool VisibleInPicker { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}

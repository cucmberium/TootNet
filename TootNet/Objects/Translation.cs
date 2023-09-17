using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Translation : BaseObject
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("detected_source_language")]
        public string DetectedSourceLanguage { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
}

using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class StatusSource : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }
    }
}

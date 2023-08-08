using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class AnnouncementStatus
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

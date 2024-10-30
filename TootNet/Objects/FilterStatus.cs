using Newtonsoft.Json;
using TootNet.Internal;


namespace TootNet.Objects
{
    public class FilterStatus : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("status_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long StatusId { get; set; }
    }
}

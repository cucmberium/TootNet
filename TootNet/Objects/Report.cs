using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Report : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("action_taken")]
        public string ActionTaken { get; set; }
    }
}

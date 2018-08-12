using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class PushSubscription : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("server_key")]
        public string ServerKey { get; set; }

        [JsonProperty("alerts")]
        public string Alerts { get; set; }
    }
}

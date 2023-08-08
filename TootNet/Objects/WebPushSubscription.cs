using Newtonsoft.Json;
using System.Collections.Generic;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class WebPushSubscription : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("server_key")]
        public string ServerKey { get; set; }

        [JsonProperty("alerts")]
        public IDictionary<string, bool> Alerts { get; set; }
    }
}

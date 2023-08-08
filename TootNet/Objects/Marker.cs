using System;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Marker : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}

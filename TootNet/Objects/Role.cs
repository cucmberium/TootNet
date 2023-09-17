using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Role : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("permissions")]
        public int Permissions { get; set; }

        [JsonProperty("highlighted")]
        public bool Highlighted { get; set; }
    }
}

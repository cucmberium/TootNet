using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class DomainBlock : BaseObject
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("digest")]
        public string Digest { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}

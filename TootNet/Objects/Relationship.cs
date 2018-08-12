using System.ComponentModel;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Relationship : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("followed_by")]
        public bool FollowedBy { get; set; }

        [JsonProperty("blocking")]
        public bool Blocking { get; set; }

        [JsonProperty("muting")]
        public bool Muting { get; set; }

        [JsonProperty("muting_boosts")]
        [DefaultValue(false)]
        public bool MutingBoosts { get; set; }

        [JsonProperty("requested")]
        public bool Requested { get; set; }

        [JsonProperty("domain_blocking")]
        [DefaultValue(false)]
        public bool DomainBlocking { get; set; }

        [JsonProperty("showing_reblogs")]
        public bool ShowingReblogs { get; set; }
    }
}

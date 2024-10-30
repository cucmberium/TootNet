using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Relationship : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("showing_reblogs")]
        public bool ShowingReblogs { get; set; }

        [JsonProperty("notifying")]
        public bool Notifying { get; set; }

        [JsonProperty("languages")]
        public IEnumerable<string> Languages { get; set; }

        [JsonProperty("followed_by")]
        public bool FollowedBy { get; set; }

        [JsonProperty("blocking")]
        public bool Blocking { get; set; }

        [JsonProperty("blocked_by")]
        public bool BlockedBy { get; set; }

        [JsonProperty("muting")]
        public bool Muting { get; set; }

        [JsonProperty("muting_notifications")]
        [DefaultValue(false)]
        public bool MutingNotifications { get; set; }

        [JsonProperty("requested")]
        public bool Requested { get; set; }

        [JsonProperty("domain_blocking")]
        public bool DomainBlocking { get; set; }
        
        [JsonProperty("endorsed")]
        public bool Endorsed { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class CredentialAccount : Account
    {
        [JsonProperty("source")]
        public CredentialAccountSource Source { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }


    public class CredentialAccountSource
    {
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("fields")]
        public IEnumerable<AccountField> Fields { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("follow_requests_count")]
        public int FollowRequestsCount { get; set; }
    }
}

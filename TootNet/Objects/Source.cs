using System.Collections.Generic;
using Newtonsoft.Json;


namespace TootNet.Objects
{
    public class Source : BaseObject
    {
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("fields")]
        public IEnumerable<Field> Fields { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }

        [JsonProperty("language")]
        public bool Language { get; set; }

        [JsonProperty("follow_requests_count")]
        public bool FollowRequestsCount { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}

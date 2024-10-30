using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Report : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("action_taken")]
        public bool ActionTaken { get; set; }

        [JsonProperty("action_taken_at")]
        public DateTime? ActionTakenAt { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("forwarded")]
        public bool Forwarded { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("status_ids")]
        [JsonConverter(typeof(StringArrayToLongArrayConverter))]
        public IEnumerable<long> StatusIds { get; set; }

        [JsonProperty("rule_ids")]
        [JsonConverter(typeof(StringArrayToLongArrayConverter))]
        public IEnumerable<long> RuleIds { get; set; }

        [JsonProperty("target_account")]
        public Account TargetAccount { get; set; }
    }
}

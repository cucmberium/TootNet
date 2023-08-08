using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Poll : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("expired")]
        public bool Expired { get; set; }

        [JsonProperty("multiple")]
        public bool Multiple { get; set; }

        [JsonProperty("votes_count")]
        public int VotesCount { get; set; }

        [JsonProperty("voters_count")]
        public int VotersCount { get; set; }

        [JsonProperty("options")]
        public int Options { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<CustomEmoji> Emojis { get; set; }

        [JsonProperty("voted")]
        public bool? Voted { get; set; }

        [JsonProperty("own_votes")]
        public IEnumerable<int> OwnVotes { get; set; }

    }
}

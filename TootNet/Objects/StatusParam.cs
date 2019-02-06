using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class StatusParam : BaseObject
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("in_reply_to_id")]
        [JsonConverter(typeof(IdConverter))]
        public long? InReplyToId { get; set; }

        [JsonProperty("media_ids")]
        public IEnumerable<long> MediaIds { get; set; }

        [JsonProperty("sensitive")]
        public bool? Sensitive { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }
        
        [JsonProperty("application_id")]
        [JsonConverter(typeof(IdConverter))]
        public long ApplicationId { get; set; }
    }
}

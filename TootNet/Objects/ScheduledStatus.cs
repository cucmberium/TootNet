using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class ScheduledStatus
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime ScheduledAt { get; set; }

        [JsonProperty("params")]
        public IEnumerable<StatusParam> Params { get; set; }

        [JsonProperty("media_attachments")]
        public IEnumerable<Attachment> MediaAttachments { get; set; }
    }
}

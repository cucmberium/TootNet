using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class ScheduledStatus : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime ScheduledAt { get; set; }

        [JsonProperty("params")]
        public ScheduledStatusParams Params { get; set; }

        [JsonProperty("media_attachments")]
        public IEnumerable<MediaAttachment> MediaAttachments { get; set; }
    }

    public class ScheduledStatusParams
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("poll")]
        public ScheduledStatusParamsPoll Poll { get; set; }

        [JsonProperty("media_ids")]
        [JsonConverter(typeof(StringArrayToLongArrayConverter))]
        public IEnumerable<long> MediaIds { get; set; }

        [JsonProperty("sensitive")]
        public bool? Sensitive { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("in_reply_to_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long? InReplyToId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("application_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long ApplicationId { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("idempotency")]
        public string Idempotency { get; set; }

        [JsonProperty("with_rate_limit")]
        public bool WithRateLimit { get; set; }
    }

    public class ScheduledStatusParamsPoll
    {
        [JsonProperty("options")]
        public IEnumerable<string> Options { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("multiple")]
        public bool? Multiple { get; set; }

        [JsonProperty("hide_totals")]
        public bool? HideTotals { get; set; }
    }
}

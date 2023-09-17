using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class StatusEdit : BaseObject
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("poll")]
        public StatusEditPoll Poll { get; set; }

        [JsonProperty("media_attachments")]
        public IEnumerable<MediaAttachment> MediaAttachments { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<CustomEmoji> Emojis { get; set; }
    }

    public class StatusEditPoll
    {
        [JsonProperty("options")]
        public IEnumerable<StatusEditPollOption> Options { get; set; }
    }

    public class StatusEditPollOption
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

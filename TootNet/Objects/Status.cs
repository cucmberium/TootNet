using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Status : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("in_reply_to_id")]
        [JsonConverter(typeof(IdConverter))]
        public long? InReplyToId { get; set; }

        [JsonProperty("in_reply_to_account_id")]
        [JsonConverter(typeof(IdConverter))]
        public long? InReplyToAccountId { get; set; }

        [JsonProperty("reblog")]
        public Status Reblog { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("reblogs_count")]
        public int ReblogsCount { get; set; }

        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }

        [JsonProperty("reblogged")]
        public bool? Reblogged { get; set; }

        [JsonProperty("favourited")]
        public bool? Favourited { get; set; }

        [JsonProperty("muted")]
        public bool? Muted { get; set; }

        [JsonProperty("sensitive")]
        public bool? Sensitive { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("media_attachments")]
        public IEnumerable<Attachment> MediaAttachments { get; set; }

        [JsonProperty("mentions")]
        public IEnumerable<Mention> Mentions { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }
    }
}

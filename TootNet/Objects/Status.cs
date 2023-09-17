using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonProperty("media_attachments")]
        public IEnumerable<MediaAttachment> MediaAttachments { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("mentions")]
        public IEnumerable<StatusMention> Mentions { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<StatusTag> Tags { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<CustomEmoji> Emojis { get; set; }

        [JsonProperty("reblogs_count")]
        public int ReblogsCount { get; set; }

        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }

        [JsonProperty("replies_count")]
        public int RepliesCount { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("in_reply_to_id")]
        [JsonConverter(typeof(IdConverter))]
        public long? InReplyToId { get; set; }

        [JsonProperty("in_reply_to_account_id")]
        [JsonConverter(typeof(IdConverter))]
        public long? InReplyToAccountId { get; set; }

        [JsonProperty("reblog")]
        public Status Reblog { get; set; }

        [JsonProperty("poll")]
        public Poll Poll { get; set; }

        [JsonProperty("card")]
        public PreviewCard Card { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("edited_at")]
        public DateTime? EditiedAt { get; set; }

        [JsonProperty("favourited")]
        public bool? Favourited { get; set; }

        [JsonProperty("reblogged")]
        public bool? Reblogged { get; set; }

        [JsonProperty("muted")]
        public bool? Muted { get; set; }

        [JsonProperty("bookmarked")]
        public bool? Bookmarked { get; set; }

        [JsonProperty("pinned")]
        public bool? Pinned { get; set; }

        [JsonProperty("filtered")]
        public IEnumerable<FilterResult> Filtered { get; set; }
    }

    public class StatusMention
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("acct")]
        public string Acct { get; set; }
    }

    public class StatusTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Announcement : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }

        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("all_day")]
        public bool AllDay { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("read")]
        public bool? Read { get; set; }

        [JsonProperty("mentions")]
        public IEnumerable<AnnouncementAccount> Mentions { get; set; }

        [JsonProperty("statuses")]
        public IEnumerable<AnnouncementStatus> Statuses { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<StatusTag> Tags { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<CustomEmoji> Emojis { get; set; }

        [JsonProperty("reactions")]
        public IEnumerable<Reaction> Reactions { get; set; }
    }

    public class AnnouncementAccount
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

    public class AnnouncementStatus
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace TootNet.Objects
{
    public class FeaturedTag : BaseObject
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("statuses_count")]
        public string StatusesCount { get; set; }

        [JsonProperty("last_status_at")]
        public DateTime LastStatusAt { get; set; }
    }
}

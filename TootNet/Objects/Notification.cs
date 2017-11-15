using System;
using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Notification : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        /// <summary>
        /// One of: "mention", "reblog", "favourite", "follow"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}

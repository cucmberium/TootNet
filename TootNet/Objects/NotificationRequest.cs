using Newtonsoft.Json;
using System;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class NotificationRequest : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("notifications_count")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int NotificationsCount { get; set; }

        [JsonProperty("last_status")]
        public Status LastStatus { get; set; }
    }
}

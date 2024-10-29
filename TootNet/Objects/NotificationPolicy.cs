using Newtonsoft.Json;
using System;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class NotificationPolicy : BaseObject
    {
        [JsonProperty("for_not_following")]
        public string ForNotFollowing { get; set; }

        [JsonProperty("for_not_followers")]
        public string ForNotFollowers { get; set; }

        [JsonProperty("for_new_accounts")]
        public string ForNewAccounts { get; set; }

        [JsonProperty("for_private_mentions")]
        public string ForPrivateMentions { get; set; }

        [JsonProperty("for_limited_accounts")]
        public string ForLimitedAccounts { get; set; }

        [JsonProperty("summary")]
        public NotificationPolicySummary Summary { get; set; }
    }

    public class NotificationPolicySummary
    {
        [JsonProperty("pending_requests_count")]
        public int PendingRequestsCount { get; set; }

        [JsonProperty("pending_notifications_count")]
        public int PendingNotificationsCount { get; set; }
    }
}

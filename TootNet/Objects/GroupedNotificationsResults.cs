using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class GroupedNotificationsResults : BaseObject
    {
        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("partial_accounts")]
        public IEnumerable<PartialAccountWithAvatar> PartialAccounts { get; set; }

        [JsonProperty("statuses")]
        public IEnumerable<Status> Statuses { get; set; }

        [JsonProperty("notification_groups")]
        public IEnumerable<NotificationGroup> NotificationGroups { get; set; }
    }

    public class PartialAccountWithAvatar
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("acct")]
        public string Acct { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("avatar_static")]
        public string AvatarStatic { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }
    }

    public class NotificationGroup
    {
        [JsonProperty("group_key")]
        public string GroupKey { get; set; }

        [JsonProperty("notifications_count")]
        public int NotificationCount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("most_recent_notification_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long MostRecentNotificationId { get; set; }

        [JsonProperty("page_min_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long PageMinId { get; set; }

        [JsonProperty("page_max_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long PageMaxId { get; set; }

        [JsonProperty("latest_page_notification_at")]
        public DateTime? LatestPageNotificationAt { get; set; }

        [JsonProperty("sample_account_ids")]
        [JsonConverter(typeof(StringArrayToLongArrayConverter))]
        public IEnumerable<long> SampleAccountIds { get; set; }

        [JsonProperty("status_id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long StatusId { get; set; }

        [JsonProperty("report")]
        public Report Report { get; set; }

        [JsonProperty("event")]
        public RelationshipSeveranceEvent Event { get; set; }

        [JsonProperty("moderation_warning")]
        public AccountWarning ModerationWarning { get; set; }
    }

    public class RelationshipSeveranceEvent
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("purged")]
        public bool Purged { get; set; }

        [JsonProperty("target_name")]
        public string TargetName { get; set; }

        [JsonProperty("relationships_count")]
        public int? RelationshipsCount { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class AccountWarning
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("status_ids")]
        [JsonConverter(typeof(StringArrayToLongArrayConverter))]
        public IEnumerable<long> StatusIds { get; set; }

        [JsonProperty("target_account")]
        public Account TargetAccount { get; set; }

        [JsonProperty("appeal")]
        public Appeal Appeal { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class Appeal
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}

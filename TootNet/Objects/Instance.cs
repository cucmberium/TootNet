using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class Instance : BaseObject
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("usage")]
        public InstanceUsage Usage { get; set; }

        [JsonProperty("thumbnail")]
        public InstanceThumbnail Thumbnail { get; set; }

        [JsonProperty("languages")]
        public IEnumerable<string> Languages { get; set; }

        [JsonProperty("configuration")]
        public InstanceConfiguration Configuration { get; set; }

        [JsonProperty("registrations")]
        public InstanceRegistrations Registrations { get; set; }

        [JsonProperty("contact")]
        public InstanceContact Contact { get; set; }

        [JsonProperty("rules")]
        public IEnumerable<Rule> Rules { get; set; }
    }

    public class InstanceUsage
    {
        [JsonProperty("users")]
        public InstanceUsageUsers Users { get; set; }
    }

    public class InstanceUsageUsers
    {
        [JsonProperty("active_month")]
        public int ActiveMonth { get; set; }
    }

    public class InstanceThumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("blurhash")]
        public string Blurhash { get; set; }

        [JsonProperty("versions")]
        public IDictionary<string, string> Versions { get; set; }
    }

    public class InstanceConfiguration
    {
        [JsonProperty("urls")]
        public InstanceConfigurationUrls Urls { get; set; }

        [JsonProperty("accounts")]
        public InstanceConfigurationAccounts Accounts { get; set; }

        [JsonProperty("statuses")]
        public InstanceConfigurationStatuses Statuses { get; set; }

        [JsonProperty("media_attachments")]
        public InstanceConfigurationMediaAttachments MediaAttachments { get; set; }

        [JsonProperty("polls")]
        public InstanceConfigurationPolls Polls { get; set; }

        [JsonProperty("translation")]
        public InstanceConfigurationTranslation Translation { get; set; }
    }

    public class InstanceConfigurationUrls
    {
        [JsonProperty("streaming")]
        public string Streaming { get; set; }
    }

    public class InstanceConfigurationAccounts
    {
        [JsonProperty("max_featured_tags")]
        public int MaxFeaturedTags { get; set; }
    }

    public class InstanceConfigurationStatuses
    {
        [JsonProperty("max_characters")]
        public int MaxCharacters { get; set; }

        [JsonProperty("max_media_attachments")]
        public int MaxMediaAttachments { get; set; }

        [JsonProperty("characters_reserved_per_url")]
        public int CharactersReservedPerUrl { get; set; }
    }

    public class InstanceConfigurationMediaAttachments
    {
        [JsonProperty("supported_mime_types")]
        public IEnumerable<string> SupportedMimeTypes { get; set; }

        [JsonProperty("image_size_limit")]
        public int ImageSizeLimit { get; set; }

        [JsonProperty("image_matrix_limit")]
        public int ImageMatrixLimit { get; set; }

        [JsonProperty("video_size_limit")]
        public int VideoSizeLimit { get; set; }

        [JsonProperty("video_frame_rate_limit")]
        public int VideoFrameRateLimit { get; set; }

        [JsonProperty("video_matrix_limit")]
        public int VideoMatrixLimit { get; set; }
    }

    public class InstanceConfigurationPolls
    {
        [JsonProperty("max_options")]
        public int MaxOptions { get; set; }

        [JsonProperty("max_characters_per_option")]
        public int MaxCharactersPerOption { get; set; }

        [JsonProperty("min_expiration")]
        public int MinExpiration { get; set; }

        [JsonProperty("max_expiration")]
        public int MaxExpiration { get; set; }
    }

    public class InstanceConfigurationTranslation
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class InstanceRegistrations
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("approval_required")]
        public bool ApprovalRequired { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class InstanceContact
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }
    }
}
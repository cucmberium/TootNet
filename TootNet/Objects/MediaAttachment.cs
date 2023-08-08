using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class MediaAttachment : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        /// <summary>
        /// One of: "image", "video", "audio", "gifv", "unknown"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("remote_url")]
        public string RemoteUrl { get; set; }

        [JsonProperty("meta")]
        public MediaAttachmentMeta Meta { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("blurhash")]
        public string Blurhash { get; set; }
    }

    public class MediaAttachmentMeta : BaseObject
    {
        [JsonProperty("original")]
        public MediaAttachmentMetaInfo Original { get; set; }

        [JsonProperty("small")]
        public MediaAttachmentMetaInfo Small { get; set; }

        [JsonProperty("focus")]
        public MediaAttachmentMetaInfo Focus { get; set; }
    }

    public class MediaAttachmentMetaInfo : BaseObject
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("aspect")]
        public double Aspect { get; set; }
    }

    public class MediaAttachmentMetaFocus : BaseObject
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}

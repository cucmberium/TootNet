using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class MediaAttachment : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        /// <summary>
        /// One of: "image", "gifv", "video", "audio", "unknown"
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

    public class MediaAttachmentMeta
    {
        /// <summary>
        /// Only returns in type: video, gifv, audio
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv, audio
        /// </summary>
        [JsonProperty("duration")]
        public double Duration { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv
        /// </summary>
        [JsonProperty("fps")]
        public int Fps { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv
        /// </summary>
        [JsonProperty("aspect")]
        public double Aspect { get; set; }

        /// <summary>
        /// Only returns in type: video, audio
        /// </summary>
        [JsonProperty("audio_encode")]
        public string AudioEncode { get; set; }

        /// <summary>
        /// Only returns in type: video, audio
        /// </summary>
        [JsonProperty("audio_bitrate")]
        public string AudioBitrate { get; set; }

        /// <summary>
        /// Only returns in type: video, audio
        /// </summary>
        [JsonProperty("audio_channels")]
        public string AudioChannels { get; set; }

        [JsonProperty("original")]
        public MediaAttachmentMetaOriginal Original { get; set; }

        /// <summary>
        /// Only returns in type: image, video, gifv
        /// </summary>
        [JsonProperty("small")]
        public MediaAttachmentMetaSmall Small { get; set; }

        /// <summary>
        /// Only returns in type: image
        /// </summary>
        [JsonProperty("focus")]
        public MediaAttachmentMetaFocus Focus { get; set; }
    }

    public class MediaAttachmentMetaOriginal
    {
        /// <summary>
        /// Only returns in type: image, video, gifv
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Only returns in type: image, video, gifv
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Only returns in type: image
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// Only returns in type: image
        /// </summary>
        [JsonProperty("aspect")]
        public double Aspect { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv
        /// </summary>
        [JsonProperty("frame_rate")]
        public string FrameRate { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv, audio
        /// </summary>
        [JsonProperty("duration")]
        public double Duration { get; set; }

        /// <summary>
        /// Only returns in type: video, gifv, audio
        /// </summary>
        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }
    }

    public class MediaAttachmentMetaSmall
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

    public class MediaAttachmentMetaFocus
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}

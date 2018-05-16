using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class StreamingApiInfo : BaseObject
    {
        [JsonProperty("streaming_api")]
        public string StreamingApi { get; set; }
    }
}

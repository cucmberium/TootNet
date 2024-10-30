using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class List : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("replies_policy")]
        public string RepliesPolicy { get; set; }
    }
}

using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class List : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

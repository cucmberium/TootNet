using Newtonsoft.Json;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Rule : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }


        [JsonProperty("text")]
        public string Text { get; set; }
    }
}

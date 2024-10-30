using Newtonsoft.Json;
using TootNet.Internal;


namespace TootNet.Objects
{
    public class FilterKeyword : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }
        
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("whole_word")]
        public bool WholeWord { get; set; }
    }
}

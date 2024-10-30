using Newtonsoft.Json;
using System.Collections.Generic;
using TootNet.Internal;


namespace TootNet.Objects
{
    public class FilterResult : BaseObject
    {
        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        [JsonProperty("keyword_matches")]
        public IEnumerable<string> KeywordMatches { get; set; }

        [JsonProperty("status_matches")]
        [JsonConverter(typeof(StringArrayToLongArrayConverter))]
        public IEnumerable<long> StatusMatches { get; set; }
    }
}

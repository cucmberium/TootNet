using System.Collections.Generic;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Tag : BaseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("history")]
        public IEnumerable<History> History { get; set; }
    }
}

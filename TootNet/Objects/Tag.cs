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
        public IEnumerable<TagHistory> History { get; set; }

        [JsonProperty("following")]
        public bool? Following { get; set; }
    }

    public class TagHistory
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("uses")]
        public string Uses { get; set; }

        [JsonProperty("accounts")]
        public string Accounts { get; set; }
    }
}

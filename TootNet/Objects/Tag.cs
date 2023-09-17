using Newtonsoft.Json;
using System.Collections.Generic;

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
        /// <summary>
        /// Unix timestamp
        /// </summary>
        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("uses")]
        public int Uses { get; set; }

        [JsonProperty("accounts")]
        public int Accounts { get; set; }
    }
}

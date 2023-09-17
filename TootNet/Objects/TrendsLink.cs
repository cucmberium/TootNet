using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class TrendsLink : PreviewCard
    {
        [JsonProperty("history")]
        public IEnumerable<TrendsLinkHistory> History { get; set; }
    }

    public class TrendsLinkHistory
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

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
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("uses")]
        public string Uses { get; set; }

        [JsonProperty("accounts")]
        public string Accounts { get; set; }
    }
}

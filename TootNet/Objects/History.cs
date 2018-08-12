using System.Collections.Generic;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class History : BaseObject
    {
        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("uses")]
        public int Uses { get; set; }

        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }
    }
}

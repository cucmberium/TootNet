using System.Collections.Generic;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Results : BaseObject
    {
        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("statuses")]
        public IEnumerable<Status> Statuses { get; set; }

        [JsonProperty("hashtags")]
        public IEnumerable<string> Hashtags { get; set; }
    }
}

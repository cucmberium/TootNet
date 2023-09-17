using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class Search : BaseObject
    {
        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("statuses")]
        public IEnumerable<Status> Statuses { get; set; }

        [JsonProperty("hashtags")]
        public IEnumerable<Tag> Hashtags { get; set; }
    }
}

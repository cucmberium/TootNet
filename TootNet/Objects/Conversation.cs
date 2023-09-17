using Newtonsoft.Json;
using System.Collections.Generic;
using TootNet.Internal;


namespace TootNet.Objects
{
    public class Conversation : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("unread")]
        public bool Unread { get; set; }

        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("last_status")]
        public Status LastStatus { get; set; }
    }
}

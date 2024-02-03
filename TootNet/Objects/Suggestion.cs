using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class Suggestion : BaseObject
    {
        [JsonProperty("source")]
        public IEnumerable<string> Source { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }
    }
}

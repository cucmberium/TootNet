using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Suggestion : BaseObject
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }
    }
}

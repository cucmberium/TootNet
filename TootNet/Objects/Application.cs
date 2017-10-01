using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Application : BaseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }
}

using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Field : BaseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

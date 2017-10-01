using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class BaseObject
    {
        [JsonIgnore]
        public string RawJson { get; set; }
    }
}

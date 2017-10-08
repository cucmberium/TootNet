using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Error : BaseObject
    {
        [JsonProperty("error")]
        public string Description { get; set; }
    }
}

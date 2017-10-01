using Newtonsoft.Json;

namespace TootNet.Objects
{
    class Error : BaseObject
    {
        [JsonProperty("error")]
        public string Description { get; set; }
    }
}

using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Error : BaseObject
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}

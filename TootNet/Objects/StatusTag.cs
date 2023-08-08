using System.Collections.Generic;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class StatusTag : BaseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

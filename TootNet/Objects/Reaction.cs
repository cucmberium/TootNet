using Newtonsoft.Json;
using System;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Reaction : BaseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("me")]
        public bool? Me { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }
    }
}

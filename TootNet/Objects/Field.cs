using System;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Field : BaseObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("verified_at")]
        public DateTime VerifiedAt { get; set; }
    }
}

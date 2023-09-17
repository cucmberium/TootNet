using Newtonsoft.Json;
using System;

namespace TootNet.Objects
{
    public class ExtendedDescription : BaseObject
    {
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}

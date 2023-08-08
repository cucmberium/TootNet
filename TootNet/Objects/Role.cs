using Newtonsoft.Json;
using System;
using TootNet.Internal;

namespace TootNet.Objects
{
    public class Role : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("highlighted")]
        public bool Highlighted { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;


namespace TootNet.Objects
{
    public class Source : BaseObject
    {
        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("sensitive")]
        public bool Sensitive { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("fields")]
        public IEnumerable<Field> Fields { get; set; }
    }
}

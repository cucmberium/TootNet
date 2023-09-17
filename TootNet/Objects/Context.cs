using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    public class Context : BaseObject
    {
        [JsonProperty("ancestors")]
        public IEnumerable<Status> Ancestors { get; set; }

        [JsonProperty("descendants")]
        public IEnumerable<Status> Descendants { get; set; }
    }
}

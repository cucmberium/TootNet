using System.Collections.Generic;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    class Context : BaseObject
    {
        [JsonProperty("ancestors")]
        public IEnumerable<Status> Ancestors { get; set; }

        [JsonProperty("descendants")]
        public IEnumerable<Status> Descendants { get; set; }
    }
}

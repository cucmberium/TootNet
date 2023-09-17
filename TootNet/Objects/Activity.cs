using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Activity : BaseObject
    {
        /// <summary>
        /// Unix timestamp
        /// </summary>
        [JsonProperty("week")]
        public long Week { get; set; }

        [JsonProperty("statuses")]
        public int Statuses { get; set; }

        [JsonProperty("logins")]
        public int Logins { get; set; }

        [JsonProperty("registrations")]
        public int Registrations { get; set; }
    }
}

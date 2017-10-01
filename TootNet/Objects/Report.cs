using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Report : BaseObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("action_taken")]
        public string ActionTaken { get; set; }
    }
}

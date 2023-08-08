using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class PollOption : BaseObject
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("votes_count")]
        public string VotesCount { get; set; }
    }
}

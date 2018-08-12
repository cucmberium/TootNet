using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TootNet.Internal;


namespace TootNet.Objects
{
    public class Filter : BaseObject
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(IdConverter))]
        public long Id { get; set; }
        
        [JsonProperty("phrase")]
        public string Phrase { get; set; }

        [JsonProperty("context")]
        public IEnumerable<string> Context { get; set; }

        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [JsonProperty("irreversible")]
        public bool Irreversible { get; set; }

        [JsonProperty("whole_word")]
        public bool WholeWord { get; set; }
    }
}

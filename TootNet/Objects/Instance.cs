﻿using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Instance : BaseObject
    {
        [JsonProperty("domain")]
        public string Uri { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("version")]
        public string Version { get; set; }
        
        [JsonProperty("urls")]
        public StreamingApiInfo Urls { get; set; }

        [JsonProperty("languages")]
        public IEnumerable<string> Languages { get; set; }

        [JsonProperty("contact_account")]
        public Account ContactAccount { get; set; }
    }
}
﻿using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class Token : BaseObject
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Unix timestamp
        /// </summary>
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}

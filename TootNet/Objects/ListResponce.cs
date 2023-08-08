using System.Collections.Generic;
using Newtonsoft.Json;

namespace TootNet.Objects
{
    /// <summary>
    /// Represents a list responce object.
    /// </summary>
    public class ListResponce<T> : List<T>, IBaseObject
    {
        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        [JsonIgnore]
        public string RawJson { get; set; }
    }
}

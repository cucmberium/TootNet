using Newtonsoft.Json;
using System.Collections.Generic;

namespace TootNet.Objects
{
    interface IBaseObject
    {
        string RawJson { get; set; }
    }

    interface ILinked
    {
        long? MaxId { get; set; }

        long? SinceId { get; set; }
    }

    public class BaseObject : IBaseObject
    {
        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        [JsonIgnore]
        public string RawJson { get; set; }
    }

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

    /// <summary>
    /// Represents a linked message object.
    /// </summary>
    public class Linked<T> : List<T>, IBaseObject, ILinked
    {
        /// <summary>
        /// Gets or sets the max id.
        /// </summary>
        [JsonIgnore]
        public long? MaxId { get; set; }

        /// <summary>
        /// Gets or sets the since id.
        /// </summary>
        [JsonIgnore]
        public long? SinceId { get; set; }

        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        [JsonIgnore]
        public string RawJson { get; set; }
    }
}

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
    /// Represents a list response object.
    /// </summary>
    public class ListResponse<T> : List<T>, IBaseObject
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
    public class Linked<T> : ListResponse<T>, ILinked
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
    }

    public class DictResponse<TKey, TValue> : Dictionary<TKey, TValue>, IBaseObject
    {
        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        [JsonIgnore]
        public string RawJson { get; set; }
    }
}

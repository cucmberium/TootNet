using Newtonsoft.Json;

namespace TootNet.Objects
{
    public class BaseObject : IBaseObject
    {
        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        [JsonIgnore]
        public string RawJson { get; set; }
    }

    interface IBaseObject
    {
        string RawJson { get; set; }
    }
}

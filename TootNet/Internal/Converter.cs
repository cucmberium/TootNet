using Newtonsoft.Json.Linq;

namespace TootNet.Internal
{
    internal static class Converter
    {
        public static T Convert<T>(string json) where T : class
        {
            return JToken.Parse(json).ToObject<T>();
        }
    }
}

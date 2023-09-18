using System.Linq;
using Newtonsoft.Json.Linq;
using TootNet.Exception;
using TootNet.Objects;

namespace TootNet.Internal
{
    internal static class Converter
    {
        public static T Convert<T>(string json) where T : class
        {
            var parsed = JToken.Parse(json);
            if (parsed.Any(x => x is JProperty jp && jp.Name == "error"))
            {
                var error = parsed.ToObject<Error>();
                error.RawJson = json;
                throw new MastodonException(error);
            }

            return parsed.ToObject<T>();
        }

        public static void ConvertError(string json)
        {
            var parsed = JToken.Parse(json);
            if (parsed.Any(x => x is JProperty jp && jp.Name == "error"))
            {
                var error = parsed.ToObject<Error>();
                error.RawJson = json;
                throw new MastodonException(error);
            }
        }
    }
}

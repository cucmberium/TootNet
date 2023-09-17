using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TootNet.Exception;
using TootNet.Objects;

namespace TootNet.Internal
{
    public class IdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    return long.Parse(reader.Value.ToString());
                case JsonToken.Integer:
                    return (long)reader.Value;
                case JsonToken.Null:
                    return null;
                default:
                    throw new JsonSerializationException("This object is not convertible");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class IdArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<long>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type != JTokenType.Array)
            {
                throw new JsonSerializationException("Expected string array but got " + token.Type);
            }

            var idList = new List<long>();
            foreach (var childToken in token.Values())
            {
                switch (childToken.Type)
                {
                    case JTokenType.String:
                        idList.Add(long.Parse(childToken.ToString()));
                        break;
                    case JTokenType.Integer:
                        idList.Add(childToken.Value<long>());
                        break;
                    default:
                        throw new JsonSerializationException("Invalid array value found" + childToken.Type);
                }
            }

            return idList;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

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

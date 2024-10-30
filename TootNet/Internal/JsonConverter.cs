using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TootNet.Internal
{
    public class StringToIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    if (reader.Value == null)
                        throw new JsonSerializationException("This object is not convertible");

                    return int.Parse(reader.Value.ToString());
                case JsonToken.Integer:
                    if (reader.Value == null)
                        throw new JsonSerializationException("This object is not convertible");

                    return (int)reader.Value;
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

    public class StringToLongConverter : JsonConverter
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
                    if (reader.Value == null)
                        throw new JsonSerializationException("This object is not convertible");

                    return long.Parse(reader.Value.ToString());
                case JsonToken.Integer:
                    if (reader.Value == null)
                        throw new JsonSerializationException("This object is not convertible");

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

    public class StringArrayToLongArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<long>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Null)
            {
                return null;
            }

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
}

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TootNet.Internal
{
    public class IdConverter : JsonConverter
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type.
        /// </summary>
        /// <param name="objectType">A <see cref="System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// <c>true</c> if this converter can perform the conversion; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">The <see cref="System.Type"/> of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long value;
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    value = long.Parse(reader.Value.ToString());
                    break;
                case JsonToken.Integer:
                    value = (long)reader.Value;
                    break;
                default:
                    throw new InvalidOperationException("This object is not a timestamp");
            }
            return value;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((long)value);
        }
    }

    internal static class Converter
    {
        public static T Convert<T>(string json) where T : class
        {
            return JToken.Parse(json).ToObject<T>();
        }
    }
}

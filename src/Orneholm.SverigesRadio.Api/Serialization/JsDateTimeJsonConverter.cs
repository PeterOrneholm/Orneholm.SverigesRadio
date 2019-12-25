using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orneholm.SverigesRadio.Api.Serialization
{
    internal class JsDateTimeJsonConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            var value = reader.GetString();
            if (value.StartsWith("/Date("))
            {
                var dateValue = value.Substring(6, value.Length - 8);
                var parts = dateValue.Split('+');
                var epochMilliseconds = double.Parse(parts[0]);
                return Epoch.AddMilliseconds(epochMilliseconds);
            }
            return DateTime.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}

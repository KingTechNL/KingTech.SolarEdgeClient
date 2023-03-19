using System.Globalization;
using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Formatters;

public class DateTimeFormatConverter : JsonConverter<DateTime>
{
    private readonly string _format;
    private readonly CultureInfo _cultureInfo;

    public DateTimeFormatConverter(string format)
    {
        _format = format;
        _cultureInfo = CultureInfo.InvariantCulture;
    }

    public DateTimeFormatConverter(string format, CultureInfo cultureInfo)
    {
        _format = format;
        _cultureInfo = cultureInfo;
    }

    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        if (value == null)
            return;

        var str = value.ToString(_format, _cultureInfo);
        writer.WriteValue(str);
    }

    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var stringValue = reader.Value?.ToString();
        if (string.IsNullOrEmpty(stringValue))
            return existingValue;

        try
        {
            var value = DateTime.ParseExact(stringValue, _format, _cultureInfo);
            return value;
        }
        catch
        {
            return existingValue;
        }
    }
}
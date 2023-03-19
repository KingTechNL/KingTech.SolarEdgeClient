using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KingTech.SolarEdgeClient.CloudApi.Formatters;

public class NestedJsonConverter<TInnerValue> : JsonConverter<TInnerValue>
{
    private readonly IEnumerable<string> _nestedObjectNames;
    private readonly string _leaveProperty;

    public NestedJsonConverter(string nestedPropertyName)
    {
        var nestedPropertyNames = nestedPropertyName
            .Split('.').Select(n => n.ToLower());

        _nestedObjectNames = nestedPropertyNames.Take(nestedPropertyNames.Count() - 1);
        _leaveProperty = nestedPropertyNames.Last();
    }
    
    public override void WriteJson(JsonWriter writer, TInnerValue? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override TInnerValue? ReadJson(JsonReader reader, Type objectType, TInnerValue? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        try
        {
            var obj = JObject.Load(reader);

            // Loop through the nested objects.
            foreach (var nestedPropertyName in _nestedObjectNames)
            {
                if (obj == null)
                    return existingValue;

                obj = obj.Children<JObject>()
                    .FirstOrDefault(x => x.Property("Name")?.Value.ToString().ToLower() == nestedPropertyName);
            }

            //Get leave property
            var prop = obj?.Property(_leaveProperty);

            return prop == null ? existingValue : prop.ToObject<TInnerValue>();
        }
        catch (Exception)
        {
            return existingValue;
        }
    }
}
using KingTech.SolarEdgeClient.CloudApi.Formatters;
using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models;

public class TimedData
{
    [JsonProperty("date")]
    [JsonConverter(typeof(DateTimeFormatConverter), "yyyy-MM-dd HH:mm:ss")]
    public DateTime Date { get; set; }

    [JsonProperty("value")]
    public double? Value { get; set; }
}
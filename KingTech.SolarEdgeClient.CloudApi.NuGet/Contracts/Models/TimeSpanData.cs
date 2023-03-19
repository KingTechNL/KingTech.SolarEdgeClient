using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models;

public record TimeSpanData
{
    [JsonProperty("energy")]
    public double Energy { get; set; }
    [JsonProperty("revenue")]
    public double Revenue { get; set; }
}
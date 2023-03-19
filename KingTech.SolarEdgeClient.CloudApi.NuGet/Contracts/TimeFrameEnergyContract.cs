using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts;

/// <summary>
/// {
///   "timeFrameEnergy":{
///     "energy":761985.8,
///     "unit":"Wh"
///   }
/// }
/// </summary>
public record TimeFrameEnergyContract()
{
    [JsonProperty("energy")]
    public double Energy { get; set; }
    [JsonProperty("unit")]
    public string Unit { get; set; }
}
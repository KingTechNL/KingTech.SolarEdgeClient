using KingTech.SolarEdgeClient.CloudApi.Contracts.Models;
using KingTech.SolarEdgeClient.CloudApi.Contracts.Models.Enums;
using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts;

/// <summary>
/// {
///   "energy": {
///     "timeUnit": "DAY",
///     "unit": "Wh",
///     "measuredBy": "INVERTER",
///     "values": [
///       {
///         "date": "2022-11-01 00:00:00",
///         "value": 6196.0
///       },
///       {
///         "date": "2022-11-02 00:00:00",
///         "value": 6146.0
///       },
///     ]
///   }
/// }
/// </summary>
public class SiteEnergyContract
{
    [JsonProperty("timeUnit")]
    public ETimeUnit TimeUnit { get; set; }

    [JsonProperty("unit")]
    public string Unit { get; set; }

    [JsonProperty("measuredBy")]
    public string MeasuredBy { get; set; }

    [JsonProperty("values")]
    public List<TimedData> Values { get; set; }
}
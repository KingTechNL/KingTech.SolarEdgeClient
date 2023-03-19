using KingTech.SolarEdgeClient.CloudApi.Contracts.Models;
using KingTech.SolarEdgeClient.CloudApi.Formatters;
using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts;

/// <summary>
/// Record containing the 'overview' response from the SolarEdge API
/// 
/// {
///   "overview":{
///     "lastUpdateTime":"2013-10-01 02:37:47",
///     "lifeTimeData":{
///       "energy":761985.75,
///       "revenue":946.13104
///     },
///     "lastYearData":{
///       "energy":761985.8,
///       "revenue":0.0
///     },
///     "lastMonthData":{
///       "energy":492736.7,
///       "revenue":0.0
///     },
///     "lastDayData":{
///       "energy":0.0,
///       "revenue":0.0
///     },
///     "currentPower":{
///       "power":0.0
///     }
///   } 
/// } 
/// </summary>
public record OverviewContract
{
    [JsonProperty("lastUpdateTime")]
    [JsonConverter(typeof(DateTimeFormatConverter), "yyyy-MM-dd HH:mm:ss")]
    public DateTime LastUpdateTime { get; set; }
    [JsonProperty("lifeTimeData")]
    public TimeSpanData LifeTimeData { get; set; }
    [JsonProperty("lastYearData")]
    public TimeSpanData LastYearData { get; set; }
    [JsonProperty("lastMonthData")]
    public TimeSpanData LastMonthData { get; set; }
    [JsonProperty("lastDayData")]
    public TimeSpanData LastDayData { get; set; }
    
    [JsonProperty("currentPower")]
    [JsonConverter(typeof(NestedJsonConverter<double>), "power")]
    public double CurrentPower { get; set; }
}
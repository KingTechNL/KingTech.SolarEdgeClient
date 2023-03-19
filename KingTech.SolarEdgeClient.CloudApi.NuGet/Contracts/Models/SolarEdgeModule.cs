using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models;


/// <summary>
/// "primaryModule": {
///   "manufacturerName": "DAH Solar",
///   "modelName": "HCMX60X9-330W Full Black",
///   "maximumPower": 330.0,
///   "temperatureCoef": -10.0
/// },
/// </summary>
public record SolarEdgeModule
{
    [JsonProperty("manufacturerName")]
    public string ManufacturerName { get; set; }
    [JsonProperty("modelName")]
    public string ModelName { get; set; }
    [JsonProperty("maximumPower")]
    public double? MaximumPower { get; set; }
    [JsonProperty("temperatureCoef")]
    public double? TemperatureCoefficient { get; set; }
}
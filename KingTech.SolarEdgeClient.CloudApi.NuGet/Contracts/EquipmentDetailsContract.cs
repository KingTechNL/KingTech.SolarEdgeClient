using KingTech.SolarEdgeClient.CloudApi.Contracts.Models.Enums;
using KingTech.SolarEdgeClient.CloudApi.Formatters;
using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts;

/// <summary>
/// "data": {
///   "count": 90,
///   "telemetries": [],
/// }
/// </summary>
public record EquipmentDetailsContract()
{
    [JsonProperty("count")]
    public int? Count { get; set; }

    [JsonProperty("telemetries")]
    public IEnumerable<TelemetryDataModel> Telemetries { get; set; }
}

/// <summary>
/// {
///   "date": "2022-12-31 03:57:14",
///   "totalActivePower": 0.0,
///   "dcVoltage": null,
///   "powerLimit": 0.0,
///   "totalEnergy": 6418720.0,
///   "temperature": 20.8984,
///   "inverterMode": "SLEEPING",
///   "operationMode": 0,
///   "L1Data": {
///     "acCurrent": 0.0,
///     "acVoltage": 235.159,
///     "acFrequency": 50.0201,
///     "apparentPower": 0.0,
///     "activePower": 0.0,
///     "reactivePower": 0.0,
///     "cosPhi": 0.0
///   }
/// },
/// </summary>
public record TelemetryDataModel
{
    [JsonProperty("date")]
    [JsonConverter(typeof(DateTimeFormatConverter), "yyyy-MM-dd HH:mm:ss")]
    public DateTime Date { get; set; }

    [JsonProperty("totalActivePower")]
    public double? TotalActivePower { get; set; }

    [JsonProperty("dcVoltage")]
    public double? DcVoltage { get; set; }

    [JsonProperty("powerLimit")]
    public double? PowerLimit { get; set; }

    [JsonProperty("totalEnergy")]
    public double? TotalEnergy { get; set; }

    [JsonProperty("temperature")]
    public double? Temperature { get; set; }

    [JsonProperty("inverterMode")]
    public EInverterMode InverterMode { get; set; }

    [JsonProperty("operationMode")]
    public EOperationMode OperationMode { get; set; }

    [JsonProperty("L1Data")]
    public PhaseDataModel? L1Data { get; set; }

    [JsonProperty("L2Data")]
    public PhaseDataModel? L2Data { get; set; }

    [JsonProperty("L3Data")]
    public PhaseDataModel? L3Data { get; set; }
}

/// <summary>
/// "L1Data": {
///   "acCurrent": 0.0,
///   "acVoltage": 235.159,
///   "acFrequency": 50.0201,
///   "apparentPower": 0.0,
///   "activePower": 0.0,
///   "reactivePower": 0.0,
///   "cosPhi": 0.0
/// }
/// </summary>
public record PhaseDataModel
{

    [JsonProperty("acCurrent")]
    public double? AcCurrent { get; set; }

    [JsonProperty("acVoltage")]
    public double? AcVoltage { get; set; }

    [JsonProperty("acFrequency")]
    public double? AcFrequency { get; set; }

    [JsonProperty("apparentPower")]
    public double? ApparentPower { get; set; }

    [JsonProperty("activePower")]
    public double? ActivePower { get; set; }

    [JsonProperty("reactivePower")]
    public double? ReactivePower { get; set; }

    [JsonProperty("cosPhi")]
    public double? CosPhi { get; set; }
}
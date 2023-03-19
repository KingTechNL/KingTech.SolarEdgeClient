using KingTech.SolarEdgeClient.CloudApi.Contracts.Models;
using KingTech.SolarEdgeClient.CloudApi.Formatters;
using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts;

/// <summary>
/// {
///   "details":{
///     "id":0,
///     "name":"site name",
///     "accountId":0,
///     "status":"Active",
///     "peakPower":9.8,
///     "currency":"EUR",
///     "installationDate":"2012-08-16 00:00:00",
///     "ptoDate": "2017-05-11",
///     "notes":"my notes",
///     "type":"Optimizers & Inverters",
///     "location":{
///       "country":"my country",
///       "state":"my state",
///       "city":"my city",
///       "address":"my address",
///       "address2":"",
///       "zip":"0000",
///       "timeZone":"GMT"
///     },
///     "alertQuantity":0,
///     "alertSeverity":"NONE",
///     "uris":{
///       "IMAGE_URI":"site image uri"
///     },
///     "publicSettings":{
///       "name":null,
///       "isPublic":false
///     }
///   }
/// } 
/// </summary>
public record SiteDetailsContract
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("accountId")]
    public int AccountId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("peakPower")]
    public double PeakPower { get; set; }

    /// <summary>
    /// ?????
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("installationDate")]
    [JsonConverter(typeof(DateTimeFormatConverter), "yyyy-MM-dd")]
    public DateTime InstallationDate { get; set; }

    [JsonProperty("lastUpdateTime")]
    [JsonConverter(typeof(DateTimeFormatConverter), "yyyy-MM-dd")]
    public DateTime LastUpdateDate { get; set; }
    
    [JsonProperty("ptoDate")]
    [JsonConverter(typeof(DateTimeFormatConverter), "yyyy-MM-dd")]
    public DateTime? PtoDate { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("alertQuantity")]
    public int? AlertsQuantity { get; set; }

    [JsonProperty("alertSeverity")]
    public string? AlertSeverity { get; set; }

    [JsonProperty("uris")]
    [JsonConverter(typeof(NestedJsonConverter<string>), "IMAGE_URI")]
    public string ImageUri { get; set; }

    [JsonProperty("location")]
    public SiteLocation Location { get; set; }

    [JsonProperty("publicSettings")]
    public SitePublicSettings PublicSettings { get; set; }

    [JsonProperty("primaryModule")]
    public SolarEdgeModule PrimaryModule { get; set; }
}
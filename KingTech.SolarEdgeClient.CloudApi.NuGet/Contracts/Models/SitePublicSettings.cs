using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models;


/// <summary>
/// "publicSettings":{
///   "name":null,
///   "isPublic":false
/// }
/// </summary>
public record SitePublicSettings
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("isPublic")]
    public bool IsPublic { get; set; }
}
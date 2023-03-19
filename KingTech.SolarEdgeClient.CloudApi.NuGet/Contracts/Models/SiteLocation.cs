using Newtonsoft.Json;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models;

/// <summary>
/// "location":{
///   "country":"my country",
///   "state":"my state",
///   "city":"my city",
///   "address":"my address",
///   "address2":"",
///   "zip":"0000",
///   "timeZone":"GMT",
///   "countryCode":"NL"
/// },
/// </summary>
public record SiteLocation
{
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("countryCode")]
    public string CountryCode { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("address2")]
    public string Address2 { get; set; }

    [JsonProperty("zip")]
    public string Zip { get; set; }

    [JsonProperty("timeZone")]
    public string TimeZone { get; set; }
}
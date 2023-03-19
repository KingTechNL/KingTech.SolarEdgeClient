using System.Globalization;
using Flurl.Http;
using KingTech.SolarEdgeClient.CloudApi.Contracts;
using KingTech.SolarEdgeClient.CloudApi.Contracts.Models.Enums;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KingTech.SolarEdgeClient.CloudApi;

/// <summary>
/// API DOCS:
/// https://knowledge-center.solaredge.com/sites/kc/files/se_monitoring_api.pdf
/// </summary>
public class SolarEdgeClient
{
    private const string BaseUrl = "https://monitoringapi.solaredge.com";

    private readonly ILogger<SolarEdgeClient> _logger;
    private readonly string _siteId;
    private readonly string _apiKey;
    private readonly FlurlClient _client;

    public SolarEdgeClient(ILogger<SolarEdgeClient> logger, string siteId, string apiKey)
    {
        _logger = logger;
        _siteId = siteId;
        _apiKey = apiKey;

        _client = new FlurlClient(BaseUrl);
    }

    /// <summary>
    /// Display the site overview data.
    /// The response includes the site current power, daily energy, monthly energy, yearly energy and life time energy.
    /// 
    /// URL: /site/{siteId}/overview
    /// Example URL: https://monitoringapi.solaredge.com/site/{siteId}/overview?api_key={apiKey}
    /// </summary>
    /// <returns></returns>
    public async Task<OverviewContract?> GetSiteOverview()
    {
        var url = Flurl.Url.Combine(BaseUrl, "site",_siteId,"overview");
        var response = await CallSolarEdgeApi(url);
        return GetModel<OverviewContract>(response, "overview");
    }

    public async Task<SiteDetailsContract?> GetSiteDetails()
    {
        var url = Flurl.Url.Combine(BaseUrl, "site", _siteId, "details");
        var response = await CallSolarEdgeApi(url);
        return GetModel<SiteDetailsContract>(response, "details");
    }

    public async Task<SiteEnergyContract?> GetSiteEnergy(DateTime start, DateTime end, ETimeUnit timeUnit = ETimeUnit.DAY)
    {
        var url = Flurl.Url.Combine(BaseUrl, "site", _siteId, "energy");

        var startString = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var endString = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var timeUnitString = timeUnit.ToString();

        var response = await CallSolarEdgeApi(url,
            new KeyValuePair<string, string>("startDate", startString),
            new KeyValuePair<string, string>("endDate", endString),
            new KeyValuePair<string, string>("timeUnit", timeUnitString)
            );
        return GetModel<SiteEnergyContract>(response, "energy");
    }

    public async Task<TimeFrameEnergyContract?> GetSiteTimeFrameEnergy(DateTime start, DateTime end)
    {
        var url = Flurl.Url.Combine(BaseUrl, "site", _siteId, "timeFrameEnergy");

        var startString = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var endString = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        var response = await CallSolarEdgeApi(url,
            new KeyValuePair<string, string>("startDate", startString),
            new KeyValuePair<string, string>("endDate", endString)
        );

        return GetModel<TimeFrameEnergyContract>(response, "timeFrameEnergy");
    }

    public async Task<SiteEnergyContract?> GetSitePower(DateTime start, DateTime end)
    {
        //https://monitoringapi.solaredge.com/site/2108513/power?startDate=2022-12-31 00:00:01&endDate=2022-12-31 23:59:59&api_key=ER3R7R1Q42BPJRIJRYS7UEQQ5QCTSZ6K
        var url = Flurl.Url.Combine(BaseUrl, "site", _siteId, "power");

        var startString = start.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        var endString = end.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        var response = await CallSolarEdgeApi(url,
            new KeyValuePair<string, string>("startTime", startString),
            new KeyValuePair<string, string>("endTime", endString)
        );
        return GetModel<SiteEnergyContract>(response, "power");
    }

    public async Task<JObject?> GetSiteInventory()
    {
        var url = Flurl.Url.Combine(BaseUrl, "site", _siteId, "inventory");

        var response = await CallSolarEdgeApi(url);
        return response; //GetModel<SiteEnergyContract>(response, "power");
    }

    public async Task<EquipmentDetailsContract?> GetSiteEquipmentDetails(string equipmentId, DateTime start, DateTime end)
    {
        var url = Flurl.Url.Combine(BaseUrl, "equipment", _siteId, equipmentId, "data");

        var startString = start.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        var endString = end.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        var response = await CallSolarEdgeApi(url,
            new KeyValuePair<string, string>("startTime", startString),
            new KeyValuePair<string, string>("endTime", endString)
        );
        return GetModel<EquipmentDetailsContract>(response, "data");
    }

    /// <summary>
    /// Call SolarEdge API and return the response as a <see cref="JObject"/>.
    /// </summary>
    /// <param name="url">The exact URL to call.</param>
    /// <returns>The response as <see cref="JObject"/></returns>
    internal async Task<JObject> CallSolarEdgeApi(string url, params KeyValuePair<string,string>[] queryParameters)
    {
        var queryParams = queryParameters
            .Select(param => $"{param.Key}={param.Value}")
            .ToList();
        queryParams.Add($"api_key={_apiKey}");

        var apiResponse = await url
            .WithHeader("Content-Type", "application/json")
            //.SetQueryParam("api_key", _apiKey)
            .SetQueryParams(queryParams)
            .WithClient(_client)
            .AllowAnyHttpStatus()
            .WithTimeout(TimeSpan.FromSeconds(5))
            .GetAsync();

        var response = await apiResponse.GetJsonAsync<JObject>();

        if (apiResponse.StatusCode != 200)
        {
            _logger.LogError("Failed to get data from SolarEdge API. Status code: {StatusCode}, Response {@Response}",
                apiResponse.StatusCode, response);
            return null;
        }

        return response;
    }

    /// <summary>
    /// Get a model from the given JObject.
    /// SolarEdge models are nested under a key.
    /// </summary>
    /// <typeparam name="TModel">The type of model to parse.</typeparam>
    /// <param name="json">The JObject to parse.</param>
    /// <param name="key">The key for the root object.</param>
    /// <returns>The parsed <see cref="TModel"/>.</returns>
    internal TModel? GetModel<TModel>(JObject json, string key)
    {
        if (json.ContainsKey(key))
            json = json[key] as JObject;
        else
            return default;

        var settings = new JsonSerializerSettings
        {
            //ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            //Formatting = Formatting.Indented,
        };
        var model = JsonConvert.DeserializeObject<TModel>(json.ToString(), settings);
        return model;
    }
}
using System.Net.Mime;
using KingTech.SolarEdgeClient.Contracts;
using KingTech.SolarEdgeClient.Extensions;
using KingTech.SolarEdgeClient.Modbus.Devices;
using KingTech.SolarEdgeClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingTech.SolarEdgeClient.Controller;

/// <summary>
/// Main controller for the P1 reader.
/// Enables basic API functionality.
/// </summary>
[ApiController]
[Route("api/[Action]")]
public class SolarEdgeApiController : ControllerBase
{

    private readonly ILogger<SolarEdgeApiController> _logger;
    private readonly ISolarEdgeService _solarEdgeService;

    /// <summary>
    /// Main controller for the P1 reader.
    /// Enables basic API functionality.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to log messages from this controller.</param>
    /// <param name="solarEdgeService">The <see cref="SolarEdgeService"/> containing all data.</param>
    public SolarEdgeApiController(ILogger<SolarEdgeApiController> logger, ISolarEdgeService solarEdgeService)
    {
        _logger = logger;
        _solarEdgeService = solarEdgeService;
    }

    /// <summary>
    /// Get a list of available SolarEdge inverters.
    /// </summary>
    /// <returns>A list of available SolarEdge inverters.</returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(List<string>), statusCode: StatusCodes.Status200OK)]
    public IActionResult GetInverters()
    {
        _logger.LogTrace($"{nameof(GetInverters)} called.");
        var inverters = _solarEdgeService.Devices.Where(d => d is Inverter)
            .Select(d => d.DeviceIdentifier).ToList();
        return Ok(inverters);
    }

    /// <summary>
    /// Get a list of available SolarEdge meters.
    /// </summary>
    /// <returns>A list of available SolarEdge meters.</returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(List<string>), statusCode: StatusCodes.Status200OK)]
    public IActionResult GetMeters()
    {
        _logger.LogTrace($"{nameof(GetMeters)} called.");
        var meters = _solarEdgeService.Devices.Where(d => d is Meter)
            .Select(d => d.DeviceIdentifier).ToList();
        return Ok(meters);
    }

    /// <summary>
    /// Get a list of available SolarEdge batteries.
    /// </summary>
    /// <returns>A list of available SolarEdge batteries.</returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(List<string>), statusCode: StatusCodes.Status200OK)]
    public IActionResult GetBatteries()
    {
        _logger.LogTrace($"{nameof(GetBatteries)} called.");
        var battery = _solarEdgeService.Devices.Where(d => d is Battery)
            .Select(d => d.DeviceIdentifier).ToList();
        return Ok(battery);
    }
    
    /// <summary>
    /// Get the latest state for the given SolarEdge inverter.
    /// </summary>
    /// <param name="id">The unique identifier of the SolarEdge inverter.</param>
    /// <returns>The latest state for the given SolarEdge inverter.</returns>
    [HttpGet("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(List<InverterContract>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetInverter(string id)
    {
        _logger.LogTrace($"{nameof(GetInverter)} called.");
        var inverter = (Inverter) _solarEdgeService.Devices.FirstOrDefault(d => d is Inverter && d.DeviceIdentifier == id);
        if (inverter == null)
            return NotFound();
        return Ok(inverter.ToContract());
    }

    /// <summary>
    /// Get the latest state for the given SolarEdge meter.
    /// </summary>
    /// <param name="id">The unique identifier of the SolarEdge meter.</param>
    /// <returns>The latest state for the given SolarEdge meter.</returns>
    [HttpGet("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(List<MeterContract>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetMeter(string id)
    {
        _logger.LogTrace($"{nameof(GetMeter)} called.");
        var meter = (Meter) _solarEdgeService.Devices.FirstOrDefault(d => d is Meter && d.DeviceIdentifier == id);
        if (meter == null)
            return NotFound();
        return Ok(meter.ToContract());
    }

    /// <summary>
    /// Get the latest state for the given SolarEdge battery.
    /// </summary>
    /// <param name="id">The unique identifier of the SolarEdge battery.</param>
    /// <returns>The latest state for the given SolarEdge battery.</returns>
    [HttpGet("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(List<BatteryContract>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBattery(string id)
    {
        _logger.LogTrace($"{nameof(GetBattery)} called.");
        var battery = (Battery) _solarEdgeService.Devices.FirstOrDefault(d => d is Battery && d.DeviceIdentifier == id);
        if (battery == null)
            return NotFound();
        return Ok(battery.ToContract());
    }
}
using System.ComponentModel.DataAnnotations;

namespace KingTech.SolarEdgeClient.Modbus.Settings;

/// <summary>
/// Settings for a SolarEdge Modbus device.
/// </summary>
public class ModbusSource
{
    /// <summary>
    /// Hostname or IP address of the SolarEdge device.
    /// </summary>
    [Required]
    public string? Host { get; init; }

    /// <summary>
    /// The port the SolarEdge device is listening on.
    /// </summary>
    public int Port { get; init; }

    /// <summary>
    /// Unit ID of the SolarEdge device.
    /// </summary>
    public byte Unit { get; init; }

    /// <summary>
    /// The amount of SolarEdge inverters connected to this modbus source.
    /// </summary>
    [Range(0, 1)]
    public int Inverters { get; init; }

    /// <summary>
    /// The amount of SolarEdge meters connected to this modbus source.
    /// </summary>
    [Range(0, 3)]
    public int Meters { get; init; }

    /// <summary>
    /// The amount of SolarEdge batteries connected to this modbus source.
    /// </summary>
    [Range(0, 2)]
    public int Batteries { get; init; }

    /// <summary>
    /// Url based on the set hostname, port and unit ID.
    /// </summary>
    internal string Url => $"{Host}:{Port}#{Unit}";
}
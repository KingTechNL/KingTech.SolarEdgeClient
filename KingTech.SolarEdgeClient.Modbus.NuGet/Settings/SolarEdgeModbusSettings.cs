using System.ComponentModel.DataAnnotations;

namespace KingTech.SolarEdgeClient.Modbus.Settings;

/// <summary>
/// Settings for the SolarEdge Modbus client.
/// </summary>
public class SolarEdgeModbusSettings
{
    /// <summary>
    /// List of SolarEdge modbus sources.
    /// </summary>
    [Required]
    [MinLength(1)]
    public ModbusSource[]? ModbusSources { get; init; }
}
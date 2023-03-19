using System.Collections.Immutable;
using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Modbus;

/// <summary>
/// Service for querying SolarEdge devices.
/// </summary>
public interface ISolarEdgeModbusClient
{
    /// <summary>
    /// List of SolarEdge devices.
    /// </summary>
    IImmutableList<IDevice> Devices { get; }

    /// <summary>
    /// Query all SolarEdge devices known to the system.
    /// </summary>
    /// <returns>An awaitable <see cref="Task"/>.</returns>
    Task QueryDevicesAsync();
}
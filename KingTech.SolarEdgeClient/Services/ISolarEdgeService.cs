using System.Collections.Immutable;
using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Services;

public interface ISolarEdgeService
{
    IImmutableList<IDevice> Devices { get; }
    void Start();
    void Stop();
}
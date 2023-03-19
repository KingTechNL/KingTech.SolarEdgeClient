using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Contracts;

public class InverterContract
{
    public string? Manufacturer { get; init; }

    public string? Model { get; init; }

    public string? Version { get; init; }

    public string? SerialNumber { get; init; }

    public ushort DeviceAddress { get; init; }

    public InverterType Type { get; init; }

    public double AcCurrent { get; init; }

    public double AcCurrentP1 { get; init; }

    public double AcCurrentP2 { get; init; }

    public double AcCurrentP3 { get; init; }

    public double AcVoltageP1ToP2 { get; init; }

    public double AcVoltageP2ToP3 { get; init; }

    public double AcVoltageP3ToP1 { get; init; }

    public double AcVoltageP1 { get; init; }

    public double AcVoltageP2 { get; init; }

    public double AcVoltageP3 { get; init; }

    public double AcPower { get; init; }

    public double AcFrequency { get; init; }

    public double AcPowerApparent { get; init; }

    public double AcPowerReactive { get; init; }

    public double AcPowerFactor { get; init; }

    public double AcTotalEnergyProduced { get; init; }

    public double DcCurrent { get; init; }

    public double DcVoltage { get; init; }

    public double DcPower { get; init; }

    public double HeatSinkTemperature { get; init; }

    public InverterStatus Status { get; init; }

    public ushort VendorStatus { get; init; }
}
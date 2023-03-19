using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Contracts;

public class MeterContract
{
    public string? Manufacturer { get; init; }

    public string? Model { get; init; }

    public string? Option { get; init; }

    public string? Version { get; init; }

    public string? SerialNumber { get; init; }

    public ushort DeviceAddress { get; init; }

    public MeterType Type { get; init; }

    public double AcCurrent { get; init; }

    public double AcCurrentP1 { get; init; }

    public double AcCurrentP2 { get; init; }

    public double AcCurrentP3 { get; init; }

    public double AcVoltageAvg { get; init; }

    public double AcVoltageP1 { get; init; }

    public double AcVoltageP2 { get; init; }

    public double AcVoltageP3 { get; init; }

    public double AcVoltageLineToLineAvg { get; init; }

    public double AcVoltageP1ToP2 { get; init; }

    public double AcVoltageP2ToP3 { get; init; }

    public double AcVoltageP3ToP1 { get; init; }

    public double AcFrequency { get; init; }

    public double AcPower { get; init; }

    public double AcPowerP1 { get; init; }

    public double AcPowerP2 { get; init; }

    public double AcPowerP3 { get; init; }

    public double AcPowerApparent { get; init; }

    public double AcPowerApparentP1 { get; init; }

    public double AcPowerApparentP2 { get; init; }

    public double AcPowerApparentP3 { get; init; }

    public double AcPowerReactive { get; init; }

    public double AcPowerReactiveP1 { get; init; }

    public double AcPowerReactiveP2 { get; init; }

    public double AcPowerReactiveP3 { get; init; }

    public double AcPowerFactor { get; init; }

    public double AcPowerFactorP1 { get; init; }

    public double AcPowerFactorP2 { get; init; }

    public double AcPowerFactorP3 { get; init; }

    public double ExportedEnergy { get; init; }

    public double ExportedEnergyP1 { get; init; }

    public double ExportedEnergyP2 { get; init; }

    public double ExportedEnergyP3 { get; init; }

    public double ImportedEnergy { get; init; }

    public double ImportedEnergyP1 { get; init; }
    
    public double ImportedEnergyP2 { get; init; }

    public double ImportedEnergyP3 { get; init; }

    public double ExportedEnergyApparent { get; init; }

    public double ExportedEnergyApparentP1 { get; init; }

    public double ExportedEnergyApparentP2 { get; init; }

    public double ExportedEnergyApparentP3 { get; init; }

    public double ImportedEnergyApparent { get; init; }

    public double ImportedEnergyApparentP1 { get; init; }

    public double ImportedEnergyApparentP2 { get; init; }

    public double ImportedEnergyApparentP3 { get; init; }

    public double ImportedEnergyReactiveQ1 { get; init; }

    public double ImportedEnergyReactiveQ1P1 { get; init; }

    public double ImportedEnergyReactiveQ1P2 { get; init; }

    public double ImportedEnergyReactiveQ1P3 { get; init; }

    public double ImportedEnergyReactiveQ2 { get; init; }

    public double ImportedEnergyReactiveQ2P1 { get; init; }

    public double ImportedEnergyReactiveQ2P2 { get; init; }

    public double ImportedEnergyReactiveQ2P3 { get; init; }

    public double ExportedEnergyReactiveQ3 { get; init; }

    public double ExportedEnergyReactiveQ3P1 { get; init; }

    public double ExportedEnergyReactiveQ3P2 { get; init; }

    public double ExportedEnergyReactiveQ3P3 { get; init; }

    public double ExportedEnergyReactiveQ4 { get; init; }

    public double ExportedEnergyReactiveQ4P1 { get; init; }

    public double ExportedEnergyReactiveQ4P2 { get; init; }

    public double ExportedEnergyReactiveQ4P3 { get; init; }

    public MeterEvents Events { get; init; }
}

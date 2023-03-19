using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Contracts;

public class BatteryContract
{
    public string? Manufacturer { get; init; }

    public string? Model { get; init; }

    public string? Version { get; init; }

    public string? SerialNumber { get; init; }

    public ushort DeviceAddress { get; init; }

    public float RatedCapacity { get; init; }

    public float MaxChargeContinuousPower { get; init; }

    public float MaxDischargeContinuousPower { get; init; }

    public float MaxChargePeakPower { get; init; }

    public float MaxDischargePeakPower { get; init; }

    public float AvgTemperature { get; init; }

    public float MaxTemperature { get; init; }

    public float Voltage { get; init; }

    public float Current { get; init; }

    public float Power { get; init; }

    public ulong LifetimeExportedEnergy { get; init; }

    public ulong LifetimeImportedEnergy { get; init; }

    public float Capacity { get; init; }

    public float Charge { get; init; }

    public float CapacityPercent { get; init; }
    
    public float ChargePercent { get; init; }

    public BatteryStatus Status { get; init; }

    public uint VendorStatus { get; init; }

    public ushort LastEvent { get; init; }
}
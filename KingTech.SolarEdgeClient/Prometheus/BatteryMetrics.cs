using KingTech.SolarEdgeClient.Modbus.Devices;
using Prometheus;

namespace KingTech.SolarEdgeClient.Prometheus;

public class BatteryMetrics : ABaseMetrics<Battery>
{
    private readonly string _serialNumber;
    
    private Gauge _deviceAddress;
    private Gauge _ratedCapacity;
    private Gauge _maxChargeContinuousPower;
    private Gauge _maxDischargeContinuousPower;
    private Gauge _maxChargePeakPower;
    private Gauge _maxDischargePeakPower;
    private Gauge _avgTemperature;
    private Gauge _maxTemperature;
    private Gauge _voltage;
    private Gauge _current;
    private Gauge _power;
    private Gauge _lifetimeExportedEnergy;
    private Gauge _lifetimeImportedEnergy;
    private Gauge _capacity;
    private Gauge _charge;
    private Gauge _capacityPercent;
    private Gauge _chargePercent;
    private Gauge _status;
    private Gauge _vendorStatus;
    private Gauge _lastEvent;

    
    public BatteryMetrics(string serialNumber)
    {
        _serialNumber = serialNumber;
        InitMetrics();
    }

    /// <inheritdoc/>
    public override void SetValues(Battery? data)
    {
        if (data == null)
            return;

        TrySet(_deviceAddress, data.DeviceAddress);
        TrySet(_ratedCapacity, data.RatedCapacity);
        TrySet(_maxChargeContinuousPower, data.MaxChargeContinuousPower);
        TrySet(_maxDischargeContinuousPower, data.MaxDischargeContinuousPower);
        TrySet(_maxChargePeakPower, data.MaxChargePeakPower);
        TrySet(_maxDischargePeakPower, data.MaxDischargePeakPower);
        TrySet(_avgTemperature, data.AvgTemperature);
        TrySet(_maxTemperature, data.MaxTemperature);
        TrySet(_voltage, data.Voltage);
        TrySet(_current, data.Current);
        TrySet(_power, data.Power);
        TrySet(_lifetimeExportedEnergy, data.LifetimeExportedEnergy);
        TrySet(_lifetimeImportedEnergy, data.LifetimeImportedEnergy);
        TrySet(_capacity, data.Capacity);
        TrySet(_charge, data.Charge);
        TrySet(_capacityPercent, data.CapacityPercent);
        TrySet(_chargePercent, data.ChargePercent);
        TrySet(_status, (int) data.Status);
        TrySet(_vendorStatus, data.VendorStatus);
        TrySet(_lastEvent, data.LastEvent);
    }

    /// <summary>
    /// Add new metric endpoints.
    /// </summary>
    private void InitMetrics()
    {
        _deviceAddress = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_deviceAddress", "Address for this battery.");
        _ratedCapacity = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_ratedCapacity", "");
        _maxChargeContinuousPower = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_maxChargeContinuousPower", "");
        _maxDischargeContinuousPower = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_maxDischargeContinuousPower", "");
        _maxChargePeakPower = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_maxChargePeakPower", "");
        _maxDischargePeakPower = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_maxDischargePeakPower", "");
        _avgTemperature = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_avgTemperature", "");
        _maxTemperature = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_maxTemperature", "");
        _voltage = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_voltage", "");
        _current = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_current", "");
        _power = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_power", "");
        _lifetimeExportedEnergy = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_lifetimeExportedEnergy", "");
        _lifetimeImportedEnergy = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_lifetimeImportedEnergy", "");
        _capacity = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_capacity", "");
        _charge = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_charge", "");
        _capacityPercent = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_capacityPercent", "");
        _chargePercent = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_chargePercent", "");
        _status = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_status", "");
        _vendorStatus = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_vendorStatus", "");
        _lastEvent = Metrics.CreateGauge($"solaredge_battery_{_serialNumber}_lastEvent", "");
    }
}
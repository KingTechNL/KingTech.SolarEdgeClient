using KingTech.SolarEdgeClient.Contracts;
using Prometheus;

namespace KingTech.SolarEdgeClient.Prometheus;

public class InverterMetrics : ABaseMetrics<InverterContract>
{
    private readonly string _serialNumber;

    //public string DeviceIdentifier => SerialNumber!;
    //public string? Manufacturer { get; init; }
    //public string? Model { get; init; }
    //public string? SerialNumber { get; init; }
    private Gauge _deviceAddress;
    private Gauge _type;
    private Gauge _acCurrent;
    private Gauge _acCurrentP1;
    private Gauge _acCurrentP2;
    private Gauge _acCurrentP3;
    private Gauge _acVoltageP1ToP2;
    private Gauge _acVoltageP2ToP3;
    private Gauge _acVoltageP3ToP1;
    private Gauge _acVoltageP1;
    private Gauge _acVoltageP2;
    private Gauge _acVoltageP3;
    private Gauge _acPower;
    private Gauge _acFrequency;
    private Gauge _acPowerApparent;
    private Gauge _acPowerReactive;
    private Gauge _acPowerFactor;
    private Gauge _acTotalEnergyProduced;
    private Gauge _dcCurrent;
    private Gauge _dcVoltage;
    private Gauge _dcPower;
    private Gauge _heatSinkTemperature;
    private Gauge _status;
    private Gauge _vendorStatus;

    public InverterMetrics(string serialNumber)
    {
        _serialNumber = serialNumber;
        InitMetrics();
    }

    /// <inheritdoc/>
    public override void SetValues(InverterContract? data)
    {
        if (data == null)
            return;

        TrySet(_deviceAddress, data.DeviceAddress);
        TrySet(_type, (int)data.Type);
        TrySet(_acCurrent, data.AcCurrent);
        TrySet(_acCurrentP1, data.AcCurrentP1);
        TrySet(_acCurrentP2, data.AcCurrentP2);
        TrySet(_acCurrentP3, data.AcCurrentP3);
        TrySet(_acVoltageP1ToP2, data.AcVoltageP1ToP2);
        TrySet(_acVoltageP2ToP3, data.AcVoltageP2ToP3);
        TrySet(_acVoltageP3ToP1, data.AcVoltageP2ToP3);
        TrySet(_acVoltageP1, data.AcVoltageP1);
        TrySet(_acVoltageP2, data.AcVoltageP2);
        TrySet(_acVoltageP3, data.AcVoltageP3);
        TrySet(_acPower, data.AcPower);
        TrySet(_acFrequency, data.AcFrequency);
        TrySet(_acPowerApparent, data.AcPowerApparent);
        TrySet(_acPowerReactive, data.AcPowerReactive);
        TrySet(_acPowerFactor, data.AcPowerFactor);
        TrySet(_acTotalEnergyProduced, data.AcTotalEnergyProduced);
        TrySet(_dcCurrent, data.DcCurrent);
        TrySet(_dcVoltage, data.DcVoltage);
        TrySet(_dcPower, data.DcPower);
        TrySet(_heatSinkTemperature, data.HeatSinkTemperature);
        TrySet(_status, (int)data.Status);
        TrySet(_vendorStatus, data.VendorStatus);
    }

    /// <summary>
    /// Add new metric endpoints.
    /// </summary>
    private void InitMetrics()
    {
        _deviceAddress = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_deviceAddress", "Address for this inverter.");
        _type = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_type", "Type of this inverter.");
        _acCurrent = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acCurrent", "Overall AC current for this inverter.");
        _acCurrentP1 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acCurrentP1", "Phase 1 AC current for this inverter.");
        _acCurrentP2 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acCurrentP2", "Phase 2 AC current for this inverter.");
        _acCurrentP3 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acCurrentP3", "Phase 3 AC current for this inverter.");
        _acVoltageP1ToP2 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acVoltageP1ToP2", "");
        _acVoltageP2ToP3 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acVoltageP2ToP3", "");
        _acVoltageP3ToP1 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acVoltageP3ToP1", "");
        _acVoltageP1 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acVoltageP1", "Phase 1 AC voltage for this inverter.");
        _acVoltageP2 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acVoltageP2", "Phase 2 AC voltage for this inverter.");
        _acVoltageP3 = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acVoltageP3", "Phase 3 AC voltage for this inverter.");
        _acPower = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acPower", "AC Power level for this inverter.");
        _acFrequency = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acFrequency", "Power frequency for this inverter.");
        _acPowerApparent = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acPowerApparent", "");
        _acPowerReactive = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acPowerReactive", "");
        _acPowerFactor = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acPowerFactor", "");
        _acTotalEnergyProduced = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_acTotalEnergyProduced", "Total amount of energy produced using this inverter.");
        _dcCurrent = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_dcCurrent", "DC current for this inverter.");
        _dcVoltage = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_dcVoltage", "DC voltage for this inverter.");
        _dcPower = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_dcPower", "DC power level for this inverter.");
        _heatSinkTemperature = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_temperature", "Current temperature for this inverter.");
        _status = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_status", "status of this inverter.");
        _vendorStatus = Metrics.CreateGauge($"solaredge_inverter_{_serialNumber}_vendorStatus", "vendor status of this inverter.");
    }
}
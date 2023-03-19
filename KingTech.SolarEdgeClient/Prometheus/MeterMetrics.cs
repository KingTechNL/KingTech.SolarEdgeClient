using KingTech.SolarEdgeClient.Modbus.Devices;
using Prometheus;

namespace KingTech.SolarEdgeClient.Prometheus;

public class MeterMetrics : ABaseMetrics<Meter>
{
    private readonly string _serialNumber;
    
    private Gauge _deviceAddress;
    private Gauge _type;
    private Gauge _acCurrent;
    private Gauge _acCurrentP1;
    private Gauge _acCurrentP2;
    private Gauge _acCurrentP3;
    private Gauge _acVoltageAvg;
    private Gauge _acVoltageP1ToP2;
    private Gauge _acVoltageP2ToP3;
    private Gauge _acVoltageP3ToP1;
    private Gauge _acVoltageP1;
    private Gauge _acVoltageP2;
    private Gauge _acVoltageP3;
    private Gauge _acVoltageLineToLineAvg;
    private Gauge _acPower;
    private Gauge _acPowerP1;
    private Gauge _acPowerP2;
    private Gauge _acPowerP3;
    private Gauge _acFrequency;
    private Gauge _acPowerApparent;
    private Gauge _acPowerApparentP1;
    private Gauge _acPowerApparentP2;
    private Gauge _acPowerApparentP3;
    private Gauge _acPowerReactive;
    private Gauge _acPowerReactiveP1;
    private Gauge _acPowerReactiveP2;
    private Gauge _acPowerReactiveP3;
    private Gauge _acPowerFactor;
    private Gauge _acPowerFactorP1;
    private Gauge _acPowerFactorP2;
    private Gauge _acPowerFactorP3;
    private Gauge _exportedEnergy;
    private Gauge _exportedEnergyP1;
    private Gauge _exportedEnergyP2;
    private Gauge _exportedEnergyP3;
    private Gauge _importedEnergy;
    private Gauge _importedEnergyP1;
    private Gauge _importedEnergyP2;
    private Gauge _importedEnergyP3;
    private Gauge _exportedEnergyApparent;
    private Gauge _exportedEnergyApparentP1;
    private Gauge _exportedEnergyApparentP2;
    private Gauge _exportedEnergyApparentP3;
    private Gauge _importedEnergyApparent;
    private Gauge _importedEnergyApparentP1;
    private Gauge _importedEnergyApparentP2;
    private Gauge _importedEnergyApparentP3;
    private Gauge _importedEnergyReactiveQ1;
    private Gauge _importedEnergyReactiveQ1P1;
    private Gauge _importedEnergyReactiveQ1P2;
    private Gauge _importedEnergyReactiveQ1P3;
    private Gauge _importedEnergyReactiveQ2;
    private Gauge _importedEnergyReactiveQ2P1;
    private Gauge _importedEnergyReactiveQ2P2;
    private Gauge _importedEnergyReactiveQ2P3;
    private Gauge _exportedEnergyReactiveQ3;
    private Gauge _exportedEnergyReactiveQ3P1;
    private Gauge _exportedEnergyReactiveQ3P2;
    private Gauge _exportedEnergyReactiveQ3P3;
    private Gauge _exportedEnergyReactiveQ4;
    private Gauge _exportedEnergyReactiveQ4P1;
    private Gauge _exportedEnergyReactiveQ4P2;
    private Gauge _exportedEnergyReactiveQ4P3;

    public MeterMetrics(string serialNumber)
    {
        _serialNumber = serialNumber;
        InitMetrics();
    }

    /// <inheritdoc/>
    public override void SetValues(Meter? data)
    {
        if (data == null)
            return;

        TrySet(_deviceAddress, data.DeviceAddress);
        TrySet(_type, (int) data.Type);
        TrySet(_acCurrent, data.AcCurrent);
        TrySet(_acCurrentP1, data.AcCurrentP1);
        TrySet(_acCurrentP2, data.AcCurrentP2);
        TrySet(_acCurrentP3, data.AcCurrentP3);
        TrySet(_acVoltageAvg, data.AcVoltageAvg);
        TrySet(_acVoltageP1ToP2, data.AcVoltageP1ToP2);
        TrySet(_acVoltageP2ToP3, data.AcVoltageP2ToP3);
        TrySet(_acVoltageP3ToP1, data.AcVoltageP3ToP1);
        TrySet(_acVoltageP1, data.AcVoltageP1);
        TrySet(_acVoltageP2, data.AcVoltageP2);
        TrySet(_acVoltageP3, data.AcVoltageP3);
        TrySet(_acVoltageLineToLineAvg, data.AcVoltageLineToLineAvg);
        TrySet(_acPower, data.AcPower);
        TrySet(_acPowerP1, data.AcPowerP1);
        TrySet(_acPowerP2, data.AcPowerP2);
        TrySet(_acPowerP3, data.AcPowerP3);
        TrySet(_acFrequency, data.AcFrequency);
        TrySet(_acPowerApparent, data.AcPowerApparent);
        TrySet(_acPowerApparentP1, data.AcPowerApparentP1);
        TrySet(_acPowerApparentP2, data.AcPowerApparentP2);
        TrySet(_acPowerApparentP3, data.AcPowerApparentP3);
        TrySet(_acPowerReactive, data.AcPowerReactive);
        TrySet(_acPowerReactiveP1, data.AcPowerReactiveP1);
        TrySet(_acPowerReactiveP2, data.AcPowerReactiveP2);
        TrySet(_acPowerReactiveP3, data.AcPowerReactiveP3);
        TrySet(_acPowerFactor, data.AcPowerFactor);
        TrySet(_acPowerFactorP1, data.AcPowerFactorP1);
        TrySet(_acPowerFactorP2, data.AcPowerFactorP2);
        TrySet(_acPowerFactorP3, data.AcPowerFactorP3);
        TrySet(_exportedEnergy, data.ExportedEnergy);
        TrySet(_exportedEnergyP1, data.ExportedEnergyP1);
        TrySet(_exportedEnergyP2, data.ExportedEnergyP2);
        TrySet(_exportedEnergyP3, data.ExportedEnergyP3);
        TrySet(_importedEnergy, data.ImportedEnergy);
        TrySet(_importedEnergyP1, data.ImportedEnergyP1);
        TrySet(_importedEnergyP2, data.ImportedEnergyP2);
        TrySet(_importedEnergyP3, data.ImportedEnergyP3);
        TrySet(_exportedEnergyApparent, data.ExportedEnergyApparent);
        TrySet(_exportedEnergyApparentP1, data.ExportedEnergyApparentP1);
        TrySet(_exportedEnergyApparentP2, data.ExportedEnergyApparentP2);
        TrySet(_exportedEnergyApparentP3, data.ExportedEnergyApparentP3);
        TrySet(_importedEnergyApparent, data.ImportedEnergyApparent);
        TrySet(_importedEnergyApparentP1, data.ImportedEnergyApparentP1);
        TrySet(_importedEnergyApparentP2, data.ImportedEnergyApparentP2);
        TrySet(_importedEnergyApparentP3, data.ImportedEnergyApparentP3);
        TrySet(_importedEnergyReactiveQ1, data.ImportedEnergyReactiveQ1);
        TrySet(_importedEnergyReactiveQ1P1, data.ImportedEnergyReactiveQ1P1);
        TrySet(_importedEnergyReactiveQ1P2, data.ImportedEnergyReactiveQ1P2);
        TrySet(_importedEnergyReactiveQ1P3, data.ImportedEnergyReactiveQ1P3);
        TrySet(_importedEnergyReactiveQ2, data.ImportedEnergyReactiveQ2);
        TrySet(_importedEnergyReactiveQ2P1, data.ImportedEnergyReactiveQ2P1);
        TrySet(_importedEnergyReactiveQ2P2, data.ImportedEnergyReactiveQ2P2);
        TrySet(_importedEnergyReactiveQ2P3, data.ImportedEnergyReactiveQ2P3);
        TrySet(_exportedEnergyReactiveQ3, data.ExportedEnergyReactiveQ3);
        TrySet(_exportedEnergyReactiveQ3P1, data.ExportedEnergyReactiveQ3P1);
        TrySet(_exportedEnergyReactiveQ3P2, data.ExportedEnergyReactiveQ3P2);
        TrySet(_exportedEnergyReactiveQ3P3, data.ExportedEnergyReactiveQ3P3);
        TrySet(_exportedEnergyReactiveQ4, data.ExportedEnergyReactiveQ4);
        TrySet(_exportedEnergyReactiveQ4P1, data.ExportedEnergyReactiveQ4P1);
        TrySet(_exportedEnergyReactiveQ4P2, data.ExportedEnergyReactiveQ4P2);
        TrySet(_exportedEnergyReactiveQ4P3, data.ExportedEnergyReactiveQ4P3);
    }

    /// <summary>
    /// Add new metric endpoints.
    /// </summary>
    private void InitMetrics()
    {
        _deviceAddress = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_deviceAddress", "");
        _type = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_type", "");
        _acCurrent = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acCurrent", "");
        _acCurrentP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acCurrentP1", "");
        _acCurrentP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acCurrentP2", "");
        _acCurrentP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acCurrentP3", "");
        _acVoltageAvg = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageAvg", "");
        _acVoltageP1ToP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageP1ToP2", "");
        _acVoltageP2ToP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageP2ToP3", "");
        _acVoltageP3ToP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageP3ToP1", "");
        _acVoltageP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageP1", "");
        _acVoltageP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageP2", "");
        _acVoltageP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageP3", "");
        _acVoltageLineToLineAvg = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acVoltageLineToLineAvg", "");
        _acPower = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPower", "");
        _acPowerP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerP1", "");
        _acPowerP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerP2", "");
        _acPowerP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerP3", "");
        _acFrequency = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acFrequency", "");
        _acPowerApparent = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerApparent", "");
        _acPowerApparentP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerApparentP1", "");
        _acPowerApparentP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerApparentP2", "");
        _acPowerApparentP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerApparentP3", "");
        _acPowerReactive = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerReactive", "");
        _acPowerReactiveP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerReactiveP1", "");
        _acPowerReactiveP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerReactiveP2", "");
        _acPowerReactiveP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerReactiveP3", "");
        _acPowerFactor = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerFactor", "");
        _acPowerFactorP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerFactorP1", "");
        _acPowerFactorP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerFactorP2", "");
        _acPowerFactorP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_acPowerFactorP3", "");
        _exportedEnergy = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergy", "");
        _exportedEnergyP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyP1", "");
        _exportedEnergyP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyP2", "");
        _exportedEnergyP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyP3", "");
        _importedEnergy = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergy", "");
        _importedEnergyP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyP1", "");
        _importedEnergyP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyP2", "");
        _importedEnergyP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyP3", "");
        _exportedEnergyApparent = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyApparent", "");
        _exportedEnergyApparentP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyApparentP1", "");
        _exportedEnergyApparentP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyApparentP2", "");
        _exportedEnergyApparentP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_exportedEnergyApparentP3", "");
        _importedEnergyApparent = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyApparent", "");
        _importedEnergyApparentP1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyApparentP1", "");
        _importedEnergyApparentP2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyApparentP2", "");
        _importedEnergyApparentP3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyApparentP3", "");
        _importedEnergyReactiveQ1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ1", "");
        _importedEnergyReactiveQ1P1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ1P1", "");
        _importedEnergyReactiveQ1P2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ1P2", "");
        _importedEnergyReactiveQ1P3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ1P3", "");
        _importedEnergyReactiveQ2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ2", "");
        _importedEnergyReactiveQ2P1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ2P1", "");
        _importedEnergyReactiveQ2P2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ2P2", "");
        _importedEnergyReactiveQ2P3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ2P3", "");
        _exportedEnergyReactiveQ3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ3", "");
        _exportedEnergyReactiveQ3P1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ3P1", "");
        _exportedEnergyReactiveQ3P2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ3P2", "");
        _exportedEnergyReactiveQ3P3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ3P3", "");
        _exportedEnergyReactiveQ4 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ4", "");
        _exportedEnergyReactiveQ4P1 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ4P1", "");
        _exportedEnergyReactiveQ4P2 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ4P2", "");
        _exportedEnergyReactiveQ4P3 = Metrics.CreateGauge($"solaredge_meter_{_serialNumber}_importedEnergyReactiveQ4P3", "");
    }
}
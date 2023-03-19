using KingTech.SolarEdgeClient.MessageBroker;
using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Prometheus;

/// <summary>
/// This service adds p1 metrics to the prometheus metrics endpoint.
/// A unique metric is added for every numeric value in the P1 spec.
/// </summary>
public class PrometheusMetricPublisher
{
    private readonly ILogger<PrometheusMetricPublisher> _logger;
    private readonly IMessageBroker<IDevice> _messageBroker;

    private readonly Dictionary<string, InverterMetrics> _inverterMetrics = new();
    private readonly Dictionary<string, MeterMetrics> _meterMetrics = new();
    private readonly Dictionary<string, BatteryMetrics> _batteryMetrics = new();

    /// <summary>
    /// This service adds p1 metrics to the prometheus metrics endpoint.
    /// A unique metric is added for every numeric value in the P1 spec.
    /// </summary>
    /// <param name="logger"><see cref="ILogger"/> for this service.</param>
    /// <param name="messageBroker">The <see cref="IDevice"/> to subscribe to new P1 messages.</param>
    public PrometheusMetricPublisher(ILogger<PrometheusMetricPublisher> logger, IMessageBroker<IDevice> messageBroker)
    {
        _logger = logger;
        _messageBroker = messageBroker;
    }

    /// <summary>
    /// Start listening for P1 messages and update metric values accordingly.
    /// </summary>
    public void Start()
    {
        _messageBroker.Subscribe(HandleMessage);
    }

    /// <summary>
    /// Stop listening for P1 messages.
    /// </summary>
    public void Stop()
    {
        _messageBroker.Unsubscribe(HandleMessage);
    }

    /// <summary>
    /// Handle incoming messages.
    /// </summary>
    /// <param name="incomingMessage">The message to handle.</param>
    private void HandleMessage(IDevice incomingMessage)
    {
        switch (incomingMessage)
        {
            //handle new inverter messages.
            case Inverter inverter:
                if (!_inverterMetrics.TryGetValue(inverter.DeviceIdentifier, out var inverterMetrics))
                {
                    inverterMetrics = new InverterMetrics(inverter.DeviceIdentifier);
                    _inverterMetrics.Add(inverter.DeviceIdentifier, inverterMetrics);
                }
                inverterMetrics.SetValues(inverter);
                break;
            //Handle new meter messages.
            case Meter meter:
                if (!_meterMetrics.TryGetValue(meter.DeviceIdentifier, out var meterMetrics))
                {
                    meterMetrics = new MeterMetrics(meter.DeviceIdentifier);
                    _meterMetrics.Add(meter.DeviceIdentifier, meterMetrics);
                }
                meterMetrics.SetValues(meter);
                break;
            //Handle new battery messages.
            case Battery battery:
                if (!_batteryMetrics.TryGetValue(battery.DeviceIdentifier, out var batteryMetrics))
                {
                    batteryMetrics = new BatteryMetrics(battery.DeviceIdentifier);
                    _batteryMetrics.Add(battery.DeviceIdentifier, batteryMetrics);
                }
                batteryMetrics.SetValues(battery);
                break;
        }
    }
}
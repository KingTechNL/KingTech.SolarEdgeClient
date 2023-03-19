using System.Collections.Immutable;
using KingTech.SolarEdgeClient.MessageBroker;
using KingTech.SolarEdgeClient.Modbus;
using KingTech.SolarEdgeClient.Modbus.Devices;

namespace KingTech.SolarEdgeClient.Services;

public class SolarEdgeService : ISolarEdgeService
{
    public IImmutableList<IDevice> Devices => _client.Devices;

    private readonly ILogger<SolarEdgeService> _logger;
    private readonly GeneralSettings _generalSettings;
    private readonly ISolarEdgeModbusClient _client;
    private readonly IMessageBroker<IDevice> _messageBroker;

    private TimerAsync _timer;

    public SolarEdgeService(ILogger<SolarEdgeService> logger, GeneralSettings generalSettings, ISolarEdgeModbusClient client, IMessageBroker<IDevice> messageBroker)
    {
        _logger = logger;
        _generalSettings = generalSettings;
        _client = client;
        _messageBroker = messageBroker;
    }

    public void Start()
    {


        // Start the timer
        _timer = new TimerAsync(Poll, _generalSettings.PollRate, _generalSettings.PollRate);
    }

    public void Stop()
    {
        _timer.StopAsync().Wait();
    }

    private async Task Poll(CancellationToken cancellationToken)
    {
        _logger.LogTrace("Polling SolarEdge");
        await _client.QueryDevicesAsync();
        foreach (var device in _client.Devices)
            _messageBroker.Enqueue(device);
    }
}
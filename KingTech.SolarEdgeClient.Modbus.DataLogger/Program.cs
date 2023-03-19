// See https://aka.ms/new-console-template for more information
using KingTech.SolarEdgeClient.Modbus;
using KingTech.SolarEdgeClient.Modbus.Settings;
using Microsoft.Extensions.Logging;
using NLog.Config;
using NLog.Extensions.Logging;


var ipAddress = "192.168.2.192";
ushort port = 1502;

var nlogConfigFile = "NLog.Testing.config";
var loggerFactory = new NLogLoggerFactory();
NLog.LogManager.Configuration = new XmlLoggingConfiguration(nlogConfigFile);
var logger = loggerFactory.CreateLogger("SolarEdgeDataLogger");
logger.LogInformation("Connecting to SolarEdge on {ipAddress}:{port}...", ipAddress, port);

var client = new SolarEdgeModbusClient(loggerFactory, new SolarEdgeModbusSettings
{
    ModbusSources = new[]
    {
        new ModbusSource()
        {
            Host = ipAddress,
            Port = port,
            Unit = 1,
            Inverters = 1,
            Meters = 0,
            Batteries = 0
        }
    }
});


while (true)
{
    await client.QueryDevicesAsync();
    var data = client.Devices[0];
    if (data != null)
    {
        logger.LogInformation("Read the following data: {@Data}", data);
    }
    else
    {
        logger.LogInformation("No data read...");
    }

    await Task.Delay(2000);
}
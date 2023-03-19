using KingTech.SolarEdgeClient.Modbus;
using KingTech.SolarEdgeClient.Modbus.Settings;
using KingTech.SolarEdgeClient.UnitTests.Helpers;

namespace KingTech.SolarEdgeClient.UnitTests;

[TestClass]
public class ModbusClientTests
{
    private string _ipAddress;
    private int _port;

    [TestInitialize]
    public void Setup()
    {
        _ipAddress = "192.168.2.152";
        _port = 1502;
    }

    [TestMethod]
    public async Task Test1()
    {
        //assign
        var client = new SolarEdgeModbusClient(TestHelpers.LoggerFactory, new SolarEdgeModbusSettings
            {
                ModbusSources = new[]
                {
                    new ModbusSource()
                    {
                        Host = _ipAddress,
                        Port = _port,
                        Unit = 1,
                        Inverters = 1,
                        Meters = 0,
                        Batteries = 0
                    }
                }
            });
        
        //act
        await client.QueryDevicesAsync();
        var data = client.Devices[0];

        //assert
        Assert.IsNotNull(data);
    }
}
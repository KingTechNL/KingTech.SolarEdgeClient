using System.Net;
using FluentModbus;
using KingTech.SolarEdgeClient.Modbus.Devices;
using KingTech.SolarEdgeClient.Modbus.Reader.Attributes;
using Microsoft.Extensions.Logging;

namespace KingTech.SolarEdgeClient.Modbus.Reader;

/// <summary>
/// Class for reading values from SolarEdge modbus devices.
/// </summary>
public class ModbusReader
{
    private readonly ILogger<ModbusReader> _logger;

    private readonly string _host;
    private readonly int _port;
    private readonly byte _unit;

    private readonly ModbusTcpClient _modbusClient = new();
    private readonly SemaphoreSlim _modbusLock = new(1);

    /// <summary>
    /// Class for reading values from SolarEdge modbus devices.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> for logging from this class.</param>
    /// <param name="host">The Hostname/IP address to read from.</param>
    /// <param name="port">The Port the modbus device is listening on.</param>
    /// <param name="unit">The unit ID for this modbus device.</param>
    public ModbusReader(ILogger<ModbusReader> logger, string host, int port, byte unit)
    {
        _logger = logger;
        _host = host;
        _port = port;
        _unit = unit;
    }

    /// <summary>
    /// Read the data for the given device type.
    /// </summary>
    /// <typeparam name="TDevice">The device type to read data for.</typeparam>
    /// <param name="startRegister">The first key in the modbus register data can be read from.</param>
    /// <returns>An awaitable <see cref="Task"/> resulting in the <see cref="IDevice"/> containing all data.</returns>
    /// <exception cref="ModbusReadException">An exception can be thrown if no data could be read.</exception>
    public async Task<TDevice> ReadDeviceAsync<TDevice>(ushort startRegister) 
        where TDevice : IDevice
    {
        await _modbusLock.WaitAsync();
        try
        {
            // Ensure the client is connected
            if (!_modbusClient.IsConnected)
                Reconnect();

            _logger.LogDebug("Reading {device} at address 0x{register} from \"{host}\" and unit {unit}...", 
                typeof(TDevice).Name, $"{startRegister:X4}", _host, _unit);

            // Create a list of all relative register addresses that need to be read
            var relativeAddressesToRead = typeof(TDevice).GetProperties().SelectMany(prop => {
                var attribute = Attribute.GetCustomAttribute(prop, typeof(ModbusRegisterAttribute));
                return attribute is not ModbusRegisterAttribute modbusRegisterAttribute
                    ? Enumerable.Empty<ushort>()
                    : modbusRegisterAttribute.GetRelativeAddressesToRead(prop.PropertyType);
            }).OrderBy(r => r).Distinct().ToArray();

            if (relativeAddressesToRead.Length == 0)
                throw new ModbusReadException("Could not find any register addresses to read.");

            var registerCount = relativeAddressesToRead.Max() + 1;
            Memory<byte> data = new byte[registerCount * ModbusUtils.SingleRegisterSize];

            try
            {
                // Read the required registers in as large chunks as possible
                var chunkStart = relativeAddressesToRead.First();
                var chunkEnd = chunkStart;

                for (var i = 1; i < relativeAddressesToRead.Length; i++)
                {
                    var relativeAddress = relativeAddressesToRead[i];

                    // Continue until the next gap
                    if (chunkEnd + 1 == relativeAddress)
                    {
                        chunkEnd = relativeAddress;

                        // Will more registers follow?
                        if (i < relativeAddressesToRead.Length - 1)
                            continue;
                    }

                    // Read a chunk of registers
                    var chunkSize = (ushort)(chunkEnd - chunkStart + 1);
                    var startingAddress = (ushort)(startRegister + chunkStart);
                    _logger.LogInformation("Reading {chunkSize} registers at address {startingAddress}", chunkSize, startingAddress);
                    Memory<byte> chunkData = await _modbusClient.ReadHoldingRegistersAsync(_unit, startingAddress, chunkSize);
                    if (chunkData.Length != chunkSize * ModbusUtils.SingleRegisterSize)
                        throw new ModbusReadException($"Reading registers chunk failed: Expected {chunkSize * 2} bytes but received {chunkData.Length}.");
                    chunkData.CopyTo(data[(chunkStart * ModbusUtils.SingleRegisterSize)..]);

                    // Skip the gap and read the next chunk
                    chunkStart = chunkEnd = relativeAddress;
                }
            }
            catch
            {
                // Make sure the connection gets reestablished after a failed read, just in case...
                _modbusClient.Disconnect();
                throw;
            }

            return CreateDeviceInstance<TDevice>(data.Span);
        }
        finally
        {
            _modbusLock.Release();
        }
    }

    /// <summary>
    /// Reconnect to the modbus server.
    /// </summary>
    /// <exception cref="ModbusReadException"></exception>
    private void Reconnect()
    {
        _logger.LogInformation("Connecting to modbus server at \"{host}\"...", _host);

        if (!IPAddress.TryParse(_host, out var address))
            throw new ModbusReadException($"Invalid IP address: {_host}");

        var endpoint = new IPEndPoint(address, _port);

        _modbusClient.ReadTimeout = 5000;
        _modbusClient.Connect(endpoint);

        _logger.LogInformation("Modbus connection to \"{host}\" established.", _host);
    }

    /// <summary>
    /// Create an instance of the given device type and fill its properties using the given registers.
    /// </summary>
    /// <typeparam name="TDevice">The device type to create.</typeparam>
    /// <param name="registers">The registers to fetch data from.</param>
    /// <returns>The created device instance.</returns>
    private TDevice CreateDeviceInstance<TDevice>(ReadOnlySpan<byte> registers) 
        where TDevice : IDevice
    {
        // Instantiate the device
        var device = Activator.CreateInstance<TDevice>();

        // Iterate over device properties
        var properties = typeof(TDevice).GetProperties();
        foreach (var property in properties)
        {
            var attribute = Attribute.GetCustomAttribute(property, typeof(ModbusRegisterAttribute));
            if (attribute is not ModbusRegisterAttribute modbusRegisterAttribute)
                continue;

            // Read the register value
            var value = modbusRegisterAttribute.Read(registers, property.PropertyType);

            property.SetValue(device, value);
        }

        return device;
    }
}
using System.Collections.Immutable;
using KingTech.SolarEdgeClient.Modbus.Devices;
using KingTech.SolarEdgeClient.Modbus.Reader;
using KingTech.SolarEdgeClient.Modbus.Settings;
using Microsoft.Extensions.Logging;

namespace KingTech.SolarEdgeClient.Modbus
{
    /// <inheritdoc/>
    public class SolarEdgeModbusClient : ISolarEdgeModbusClient
    {
        /// <inheritdoc/>
        public IImmutableList<IDevice> Devices => _devices;

        private readonly ILogger<SolarEdgeModbusClient> _logger;
        private readonly IImmutableDictionary<ModbusSource, ModbusReader> _modbusReaders;
        private volatile IImmutableList<IDevice> _devices = ImmutableList<IDevice>.Empty;

        /// <summary>
        /// Service for querying SolarEdge devices.
        /// </summary>
        /// <param name="modbusSettings">The <see cref="SolarEdgeModbusSettings"/> containing the parameters needed for querying data from SolarEdge modbus devices.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> for logging messages from this service and the modbus devices.</param>
        public SolarEdgeModbusClient(ILoggerFactory loggerFactory, SolarEdgeModbusSettings modbusSettings)
        {
            _logger = loggerFactory.CreateLogger<SolarEdgeModbusClient>();

            // Create modbus readers
            var modbusReaderLogger = loggerFactory.CreateLogger<ModbusReader>();
            _modbusReaders = modbusSettings.ModbusSources!.ToImmutableDictionary(source => source,
                source => new ModbusReader(modbusReaderLogger, source.Host!, source.Port, source.Unit));
        }

        /// <inheritdoc/>
        public async Task QueryDevicesAsync()
        {
            // Query all modbus sources concurrently and aggregate the resulting devices
            var queryTasks = _modbusReaders
                .Select(p => QueryModbusSourceAsync(p.Key, p.Value)).ToArray();
            await Task.WhenAll(queryTasks);
            _devices = queryTasks.SelectMany(task => task.Result).ToImmutableList();
        }

        /// <summary>
        /// Query all devices connected to the given modbus source.
        /// </summary>
        /// <param name="modbusSource">The <see cref="ModbusSource"/> to query.</param>
        /// <param name="modbusReader">The <see cref="ModbusReader"/> to read the values for a modbus device.</param>
        /// <returns>A list of modbus devices.</returns>
        private async Task<IReadOnlyCollection<IDevice>> QueryModbusSourceAsync(ModbusSource modbusSource, ModbusReader modbusReader)
        {
            _logger.LogDebug("Querying devices from {url}...", modbusSource.Url);

            var devices = new List<IDevice>();

            //Get all SolarEdge inverters.
            try
            {
                foreach (var address in DeviceAddresses.Inverters.Take(modbusSource.Inverters))
                    devices.Add(await modbusReader.ReadDeviceAsync<Inverter>(address));

                _logger.LogDebug("Inverters for {url} queried successfully!", modbusSource.Url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Reading inverters from {url} failed.", modbusSource.Url);
            }

            //Get all SolarEdge meters.
            try
            {
                foreach (var address in DeviceAddresses.Meters.Take(modbusSource.Meters))
                    devices.Add(await modbusReader.ReadDeviceAsync<Meter>(address));

                _logger.LogDebug("Meters for {url} queried successfully!", modbusSource.Url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Reading meters from {url} failed.", modbusSource.Url);
            }

            //Get all SolarEdge batteries.
            try
            {
                foreach (var address in DeviceAddresses.Batteries.Take(modbusSource.Batteries))
                    devices.Add(await modbusReader.ReadDeviceAsync<Battery>(address));

                _logger.LogDebug("Batteries for {url} queried successfully!", modbusSource.Url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Reading batteries from {url} failed.", modbusSource.Url);
            }

            return devices.AsReadOnly();
        }
    }
}

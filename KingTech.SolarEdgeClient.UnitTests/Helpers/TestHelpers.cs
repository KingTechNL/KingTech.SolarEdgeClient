using Microsoft.Extensions.Logging;

namespace KingTech.SolarEdgeClient.UnitTests.Helpers;

public static class TestHelpers
{
    /// <summary>
    /// Create a new ILogger instance.
    /// </summary>
    /// <typeparam name="TLogger">The ILogger subtype.</typeparam>
    /// <returns>A new ILogger instance for the given subtype.</returns>
    public static ILogger<TLogger> CreateLogger<TLogger>() => LoggerFactory.CreateLogger<TLogger>();

    /// <summary>
    /// UnitTestLogging logger factory.
    /// </summary>
    public static ILoggerFactory LoggerFactory => UnitTestLogging.NLoggerFactory;

    /// <summary>
    /// Get all properties of a type and its supertypes.
    /// </summary>
    /// <param name="objectType">The type to get all properties for.</param>
    /// <returns>All properties for the given type and its supertypes.</returns>
    public static IEnumerable<string> GetAllProperties(this Type objectType)
    {
        var properties = objectType.GetInterfaces().SelectMany(GetAllProperties).ToList();
        properties.AddRange(objectType.GetProperties().Select(p => p.Name));
        return properties;
    }

    /// <summary>
    /// Wait for a condition to be true.
    /// </summary>
    /// <param name="condition">The condition to wait for.</param>
    /// <param name="timeout">The maximum time to wait.</param>
    /// <param name="frequency">The polling frequency.</param>
    /// <returns>True if the condition holds within given timeout, false otherwise.</returns>
    public static async Task<bool> WaitFor(Func<bool> condition, TimeSpan timeout, TimeSpan? frequency = null)
    {
        try
        {
            await WaitUntil(condition, timeout, frequency);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Blocks while condition is true or timeout occurs.
    /// </summary>
    /// <param name="condition">The condition that will perpetuate the block.</param>
    /// <param name="frequency">The frequency at which the condition will be check, in milliseconds.</param>
    /// <param name="timeout">Timeout in milliseconds.</param>
    /// <exception cref="TimeoutException"></exception>
    /// <returns></returns>
    public static async Task WaitWhile(Func<bool> condition, TimeSpan? timeout = null, TimeSpan? frequency = null)
    {
        var waitTask = Task.Run(async () =>
        {
            while (condition()) await Task.Delay(frequency.GetValueOrDefault(TimeSpan.FromMilliseconds(25)));
        });

        if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout.GetValueOrDefault(TimeSpan.Zero))))
            throw new TimeoutException();
    }

    /// <summary>
    /// Blocks until condition is true or timeout occurs.
    /// </summary>
    /// <param name="condition">The break condition.</param>
    /// <param name="frequency">The frequency at which the condition will be checked.</param>
    /// <param name="timeout">The timeout in milliseconds.</param>
    /// <returns></returns>
    public static async Task WaitUntil(Func<bool> condition, TimeSpan? timeout = null, TimeSpan? frequency = null)
    {
        var waitTask = Task.Run(async () =>
        {
            while (!condition()) await Task.Delay(frequency.GetValueOrDefault(TimeSpan.FromMilliseconds(25)));
        });

        if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout.GetValueOrDefault(TimeSpan.Zero))))
            throw new TimeoutException();
    }
}
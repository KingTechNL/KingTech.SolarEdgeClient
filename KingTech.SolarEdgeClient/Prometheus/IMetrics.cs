using Prometheus;

namespace KingTech.SolarEdgeClient.Prometheus;

/// <summary>
/// Model containing prometheus metric values.
/// </summary>
/// <typeparam name="TModel">The <see cref="TModel"/> for which these metrics are.</typeparam>
public interface IMetrics<TModel>
{
    /// <summary>
    /// Set values for metric endpoints.
    /// </summary>
    /// <param name="data">The <see cref="TModel"/> to set values for.</param>
    public void SetValues(TModel? data);
}

/// <inheritdoc/>
public abstract class ABaseMetrics<TModel> : IMetrics<TModel>
    where TModel : class
{
    /// <inheritdoc/>
    public abstract void SetValues(TModel? data);

    /// <summary>
    /// Set metrics for all P1 values.
    /// </summary>
    /// <param name="gauge">The gauge to set the value for.</param>
    /// <param name="value">The value to set.</param>
    protected static void TrySet(Gauge gauge, double? value)
    {
        if (value != null)
            gauge.Set(value.Value);
    }
}
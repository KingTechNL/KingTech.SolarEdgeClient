namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models.Enums;

public enum EInverterMode
{
    /// <summary>
    /// Off
    /// </summary>
    OFF,
    /// <summary>
    /// Night mode
    /// </summary>
    SLEEPING,
    /// <summary>
    /// Pre-production
    /// </summary>
    STARTING,
    /// <summary>
    /// Production
    /// </summary>
    MPPT,
    /// <summary>
    /// Forced power reduction
    /// </summary>
    THROTTLED,
    /// <summary>
    /// Shutdown procedure
    /// </summary>
    SHUTTING_DOWN,
    /// <summary>
    /// Error mode
    /// </summary>
    FAULT,
    /// <summary>
    /// Maintenance
    /// </summary>
    STANDBY,
    /// <summary>
    /// Standby mode lock
    /// </summary>
    LOCKED_STDBY,
    /// <summary>
    /// Firefighters lock mode
    /// </summary>
    LOCKED_FIRE_FIGHTERS,
    /// <summary>
    /// Forced shutdown from server
    /// </summary>
    LOCKED_FORCE_SHUTDOWN,
    /// <summary>
    /// Communication timeout
    /// </summary>
    LOCKED_COMM_TIMEOUT,
    /// <summary>
    /// Inverter selflock trip
    /// </summary>
    LOCKED_INV_TRIP,
    /// <summary>
    /// Inverter self-lock on arc detection
    /// </summary>
    LOCKED_INV_ARC_DETECTED,
    /// <summary>
    /// Inverter lock due to DG mode enable
    /// </summary>
    LOCKED_DG,
    /// <summary>
    /// Inverter lock due to phase imbalance (1ph, Australia only)
    /// </summary>
    LOCKED_PHASE_BALANCER,
    /// <summary>
    /// Inverter lock due to precommissioning
    /// </summary>
    LOCKED_PRE_COMMISSIONING,
    /// <summary>
    /// Inverter lock due to
    /// </summary>
    LOCKED_INTERNAL,
}
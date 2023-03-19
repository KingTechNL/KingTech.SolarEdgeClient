namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models.Enums;

public enum EOperationMode
{
    /// <summary>
    /// On-grid
    /// </summary>
    GRID = 0,
    /// <summary>
    /// Operating in off-grid mode using PV or battery
    /// </summary>
    BATTERY = 1,
    /// <summary>
    /// Operating in off-grid mode with generator(e.g.diesel) is present
    /// </summary>
    GENERATOR = 2
}
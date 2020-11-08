using UnityEngine;
/// <summary>
/// This interface defines the methods for loading and disabling maps.
/// </summary>
public abstract class LogicalMapLoader : MonoBehaviour
{
    /// <summary>
    /// Logical representation of game maps
    /// </summary>
    public char[][][] LogicalMaps { get; set; }

    /// <summary>
    /// Initializes the logicalMaps array
    /// </summary>
    public abstract void InitializeLogicalMaps();

    /// <summary>
    /// Returns map
    /// </summary>
    public abstract char[][] LoadLogicalMap();
}

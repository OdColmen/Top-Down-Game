using UnityEngine;

/// <summary>
/// This abstract class defines the methods for loading logical maps in char arrays,
/// so they can be transformed into real GameObject maps somewhere else
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

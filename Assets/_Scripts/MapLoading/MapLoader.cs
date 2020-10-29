using UnityEngine;

/// <summary>
/// This abstract class defines the methods for loading and disabling maps.
/// </summary>
public abstract class MapLoader : MonoBehaviour
{
    /// <summary>
    /// Loads a new map
    /// </summary>
    public abstract void LoadMap();

    /// <summary>
    /// Disables current map
    /// </summary>
    public abstract void DisableMap();
}

using UnityEngine;

// This abstract class defines the methods for loading logical maps in char arrays,
// so they can be transformed into real GameObject maps somewhere else
public abstract class LogicalMapLoader : MonoBehaviour
{
    // Logical representation of game maps
    public char[][][] LogicalMaps { get; set; }

    public abstract void InitializeLogicalMaps();

    public abstract char[][] LoadLogicalMap();
}

using UnityEngine;

// This abstract class defines the methods for loading and disabling maps.
public abstract class MapLoader : MonoBehaviour
{
    public abstract void LoadMap();

    public abstract void DisableMap();
}

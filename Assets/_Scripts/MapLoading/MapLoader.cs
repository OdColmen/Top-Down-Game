using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapLoader : MonoBehaviour
{
    public abstract void LoadMap();

    public abstract void DisableMap();
}

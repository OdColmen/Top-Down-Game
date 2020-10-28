using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class loads random maps from existing prefabs.
/// It first creates a GameObject array with every map. Then, each time a new map is required,
/// it randomly choses one of them.
/// </summary>
public class RealMapLoaderFromPrefab : MapLoader
{
    [SerializeField] private GameObject MapParentPrefab = null;
    private GameObject[] maps;
    private Vector3 mapOrigin = Vector3.zero;
    private Vector3 parentOrigin = Vector3.zero;

    void Awake()
    {
        InitializeMaps();
    }

    /// <summary>
    /// Initializes the map prefabs and gets them ready for being loaded
    /// </summary>
    private void InitializeMaps()
    {
        // ----- INITIALIZE PARENT -----

        // Instantiate and set position
        GameObject mapParent = Instantiate(MapParentPrefab);
        mapParent.transform.position = parentOrigin;
        mapParent.SetActive(true);

        // ----- INITIALIZE MAPS -----

        // Set array size
        int childCount = mapParent.transform.childCount;
        maps = new GameObject[childCount];

        // Loop children
        for (int i = 0; i < childCount; i++)
        {
            // Initialize maps
            maps[i] = Instantiate(MapParentPrefab.transform.GetChild(i).gameObject);
            maps[i].transform.position = mapOrigin;
            maps[i].SetActive(false);
        }
    }

    /// <summary>
    /// Loads a random map and enables it on game
    /// </summary>
    public override void LoadMap()
    {
        // Get random between 0-mapsLength
        int random = Random.Range(0, maps.Length);

        maps[random].SetActive(true);
    }

    /// <summary>
    /// Disables current map
    /// </summary>
    public override void DisableMap()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
    }
}

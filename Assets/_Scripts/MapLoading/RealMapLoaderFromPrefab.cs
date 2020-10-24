using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMapLoaderFromPrefab : MapLoader
{
    [SerializeField] private GameObject MapParentPrefab = null;
    private GameObject[] maps;
    private Vector3 mapOrigin = Vector3.zero;
    private Vector3 parentOrigin = Vector3.zero;

    private void Awake()
    {
        InitializeMaps();
    }

    private void InitializeMaps()
    {
        // ----- INITIALIZE PARENT -----

        // Instantiate and set position
        GameObject mapParent = Instantiate(MapParentPrefab);
        mapParent.transform.position = parentOrigin;
        //mapParent.SetActive(true);

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

    public override void LoadMap()
    {
        // Get random between 0-mapsLength
        int random = Random.Range(0, maps.Length);

        maps[random].SetActive(true);
    }

    public override void DisableMap()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMapLoaderFromPrefab : MonoBehaviour
{
    [SerializeField] private GameObject MapParentPrefab = null;
    private GameObject[] maps;
    private Vector3 parentOrigin = Vector3.zero;
    private Vector3 mapOrigin = Vector3.zero;

    private void Awake()
    {
        InitializeMaps();
    }

    private void Start()
    {
        LoadRealMap();
    }

    private void InitializeMaps()
    {
        // Initialize parent
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
            maps[i] = MapParentPrefab.transform.GetChild(i).gameObject;
            maps[i].transform.position = mapOrigin;
            maps[i].SetActive(false);
        }
    }

    public void LoadRealMap()
    {
        // Get random between 0-mapsLength
        int random = Random.Range(0, maps.Length);

        maps[random].SetActive(true);
    }
}

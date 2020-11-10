using UnityEngine;

// This class loads random GameObject maps from existing Prefabs.
// It requires a map parent prefap, which must have one or more maps as its children.
public class MapLoaderFromPrefab : MapLoader
{
    [SerializeField] private GameObject mapParentPrefab = null;

    private GameObject mapsParent;
    private GameObject[] maps;

    private Vector3 mapOrigin = Vector3.zero;
    private Vector3 parentOrigin = Vector3.zero;

    void Awake()
    {
        InitializeMapsParent();
        InitializeMaps();
    }

    // Initializes the parent of all the maps
    private void InitializeMapsParent()
    {
        mapsParent = Instantiate(mapParentPrefab);
        mapsParent.transform.position = parentOrigin;
        mapsParent.SetActive(true);
    }

    // Initializes every single map and gets them ready for being loaded
    private void InitializeMaps()
    {
        // Set array size
        int childCount = mapsParent.transform.childCount;
        maps = new GameObject[childCount];

        // Initialize every map
        for (int i = 0; i < childCount; i++)
        {
            maps[i] = mapsParent.transform.GetChild(i).gameObject;
            maps[i].transform.position = mapOrigin;
            maps[i].SetActive(false);
        }
    }

    // Loads a random map and enables it on stage
    public override void LoadMap()
    {
        int random = Random.Range(0, maps.Length);
        maps[random].SetActive(true);
    }

    // Disables current map
    public override void DisableMap()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            if (maps[i].activeSelf)
            {
                maps[i].SetActive(false);
            }
        }
    }
}
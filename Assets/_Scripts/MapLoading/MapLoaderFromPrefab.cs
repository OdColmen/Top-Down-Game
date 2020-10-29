using UnityEngine;

/// <summary>
/// This class loads random GameObject maps from existing Prefabs.
/// </summary>
/// <remarks>
/// It requires a map parent prefap, which must have one or more maps as its children.
/// </remarks>
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

    /// <summary>
    /// Initializes parent of all the maps
    /// </summary>
    private void InitializeMapsParent()
    {
        mapsParent = Instantiate(mapParentPrefab);
        mapsParent.transform.position = parentOrigin;
        mapsParent.SetActive(true);
    }

    /// <summary>
    /// Initializes every single map and gets them ready for being loaded
    /// </summary>
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

    /// <summary>
    /// Loads a random map and enables it on stage
    /// </summary>
    public override void LoadMap()
    {
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
            if (maps[i].activeSelf)
            {
                maps[i].SetActive(false);
            }
        }
    }
}
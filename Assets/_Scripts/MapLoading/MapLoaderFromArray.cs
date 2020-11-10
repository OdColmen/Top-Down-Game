using UnityEngine;

// This class loads a GameObject map from a given char array.
public class MapLoaderFromArray : MapLoader
{
    private LogicalMapLoader logicalMapLoader = null;

    [SerializeField] private GameObject wallPrefab = null;
    [SerializeField] private Vector3 firstWallPosition = Vector3.zero;

    private GameObject map;
    private GameObjectPoolSystem wallPool;
    
    private Vector3 mapOrigin = Vector3.zero;

    private float wallWidth;
    private float wallHeight;

    void Awake()
    {
        InitializeMapParent();
        InitializeWallPool();
        GetWallDimentions();

        logicalMapLoader = GetComponent<LogicalMapLoader>();
    }

    private void InitializeMapParent()
    {
        map = new GameObject("Current Map");
        map.gameObject.transform.position = mapOrigin;
    }

    private void InitializeWallPool()
    {
        // Initialize pool
        int poolSize = 128;
        wallPool = GetComponent<GameObjectPoolSystem>();
        wallPool.InitializePool(wallPrefab, poolSize, map.transform);
    }

    // Gets the horizontal and vertical dimentions from the wall prefab
    private void GetWallDimentions()
    {
        wallWidth = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        wallHeight = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Loads a map to stage. 
    // First it loads a logical map (char[][]) from the LogicalMapLoader component. 
    // Then, it transforms the logical map into a real one (GameObject) and enables it on stage.
    public override void LoadMap()
    {
        // ----- LOAD LOGICAL MAP TO VARIABLE -----
        
        char wallType = 'x';
        char[][] logicalMap = logicalMapLoader.LoadLogicalMap();

        // ----- ENABLE REAL MAP ON STAGE -----

        // Enable map
        map.SetActive(true);

        // Initialize current wall position
        Vector3 pos = firstWallPosition;

        for (int row = 0; row < logicalMap.Length; row++)
        {
            for (int col = 0; col < logicalMap[row].Length; col++)
            {
                if (logicalMap[row][col] == wallType)
                {
                    // Enable wall
                    wallPool.EnableObject(pos);
                }

                // Move position to the next column
                pos += Vector3.right * wallWidth;
            }

            // Move position to the next row
            pos = new Vector3(firstWallPosition.x, pos.y - wallHeight, pos.z);
        }
    }

    // Disables the parent map and every single wall in the pool
    public override void DisableMap()
    {
        map.SetActive(false);
        wallPool.DisableObjectsInPool();
    }
}
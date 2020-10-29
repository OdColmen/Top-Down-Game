using UnityEngine;

// Required Components
[RequireComponent(typeof(MapLoaderFromArray))]

/// <summary>
/// This class loads a new map from scratch.
/// </summary>
public class MapLoaderFromScratch : MapLoader
{
    private MapLoaderFromArray mapLoader;

    // logicalMap: The map representation in a char[][] array
    private char[][] logicalMap;

    private readonly int rowSize = 16;
    private readonly int colSize = 16;

    void Awake()
    {
        // Get MapLoaderFromArray component
        mapLoader = GetComponent<MapLoaderFromArray>();

        // Set size of logicalMap
        logicalMap = new char[rowSize][];
        for (int row = 0; row < rowSize; row++)
        {
            logicalMap[row] = new char[colSize];
        }
    }

    /// <summary>
    /// Loads a new map to the logicalMap variable
    /// </summary>
    private void CreateMapFromScratch()
    {
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                char type = (Random.Range(0, 4) < 3) ? '-' : 'x';

                logicalMap[row][col] = type;
            }
        }
    }

    /// <summary>
    /// Creates a new map from scratch and calls the MapLoaderFromArray class to
    /// enable it on stage.
    /// </summary>
    public override void LoadMap()
    {
        CreateMapFromScratch();
        mapLoader.LoadMap(logicalMap, 'x');
    }

    /// <summary>
    /// Disables current map
    /// </summary>
    public override void DisableMap()
    {
        mapLoader.DisableMap();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Required Components
[RequireComponent(typeof(RealMapLoaderFromArray))]

public class LogicalMapLoaderFromScratch : MapLoader
{
    private RealMapLoaderFromArray realMapLoader;

    private readonly int rowSize = 16;
    private readonly int colSize = 16;

    private char[][] logicalMap;

    void Awake()
    {
        // Get RealMapLoaderFromArray component
        realMapLoader = GetComponent<RealMapLoaderFromArray>();

        // Set size of logicalMap
        logicalMap = new char[rowSize][];
        for (int row = 0; row < rowSize; row++)
        {
            logicalMap[row] = new char[colSize];
        }
    }

    private void CreateMapFromScratch()
    {
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                char type = (Random.Range(0, 4) < 3) ? '-' : 'x';
                
                // Set real value
                logicalMap[row][col] = type;
            }
        }
    }

    public override void LoadMap()
    {
        // Create map crom scratch
        CreateMapFromScratch();

        // Load real map
        realMapLoader.LoadMap(logicalMap, 'x');
    }

    public override void DisableMap()
    {
        realMapLoader.DisableMap();
    }
}

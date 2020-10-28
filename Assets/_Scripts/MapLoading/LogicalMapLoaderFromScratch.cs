using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Required Components
[RequireComponent(typeof(RealMapLoaderFromArray))]

/// <summary>
/// This class loads a new map from scratch.
/// Each time a new map is required, it first creates a random logical map (a char array), 
/// which then it's transformed to a real map (a GameObject).
/// </summary>
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

    /// <summary>
    /// Creates a random map on the char array[][] variable "logicalMap"
    /// </summary>
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

    /// <summary>
    /// Loads a new map from scratch and enables it on game
    /// </summary>
    public override void LoadMap()
    {
        // Create map from scratch
        CreateMapFromScratch();

        // Load real map
        realMapLoader.LoadMap(logicalMap, 'x');
    }

    /// <summary>
    /// Disables current map
    /// </summary>
    public override void DisableMap()
    {
        realMapLoader.DisableMap();
    }
}

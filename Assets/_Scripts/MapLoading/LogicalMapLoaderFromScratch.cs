using UnityEngine;
using System;

/// <summary>
/// This class loads a new map from scratch.
/// </summary>
public class LogicalMapLoaderFromScratch : LogicalMapLoader
{
    private System.Random rand;

    void Awake ()
    {
        rand = new System.Random();

        InitializeMapLoader(1, 16, 16);
    }

    /// <summary>
    /// Loads a new map to the LogicalMap member
    /// </summary>
    private void CreateMapFromScratch()
    {
        int map = 0;

        for (int row = 0; row < RowSize; row++)
        {
            for (int col = 0; col < ColSize; col++)
            {
                char type = (rand.Next(0, 6) < 1) ? 'x' : '-';

                LogicalMaps[map][row][col] = type;
            }
        }
    }

    /// <summary>
    /// Returns a new map from scratch
    /// </summary>
    public override char[][] LoadLogicalMap()
    {
        CreateMapFromScratch();

        int map = 0;
        return LogicalMaps[map];
    }
}

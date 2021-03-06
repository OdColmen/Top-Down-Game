﻿using UnityEngine;
using System;

// This class loads a new map from scratch.
public class LogicalMapLoaderFromScratch : LogicalMapLoader
{
    private System.Random rand;

    [SerializeField] private int totalRows = 16;
    [SerializeField] private int totalColumns = 16;

    void Awake ()
    {
        rand = new System.Random();

        InitializeLogicalMaps();
    }

    // Initializes the logicalMaps array as empty
    public override void InitializeLogicalMaps()
    {
        int totalMaps = 1;

        // Set size of logicalMap
        LogicalMaps = new char[totalMaps][][];
        for (int i = 0; i < totalMaps; i++)
        {
            LogicalMaps[i] = new char[totalRows][];
            for (int j = 0; j < totalRows; j++)
            {
                LogicalMaps[i][j] = new char[totalColumns];
            }
        }
    }

    // Returns a new map from scratch
    public override char[][] LoadLogicalMap()
    {
        CreateMapFromScratch();

        int map = 0;
        return LogicalMaps[map];
    }

    // Loads a new map to the LogicalMap member
    private void CreateMapFromScratch()
    {
        int map = 0;

        for (int row = 0; row < totalRows; row++)
        {
            for (int col = 0; col < totalColumns; col++)
            {
                char type = (rand.Next(0, 6) < 1) ? 'x' : '-';

                LogicalMaps[map][row][col] = type;
            }
        }
    }
}

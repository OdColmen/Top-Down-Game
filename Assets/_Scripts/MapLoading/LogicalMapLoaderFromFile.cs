using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Required Components
[RequireComponent(typeof(RealMapLoaderFromArray))]

public class LogicalMapLoaderFromFile : MapLoader
{
    private RealMapLoaderFromArray realMapLoader;

    private FileReader fr;
    
    private readonly int rowSize = 16;
    private readonly int colSize = 16;

    private char[][][] logicalMaps;

    void Awake()
    {
        // Get RealMapLoaderFromArray component
        realMapLoader = GetComponent<RealMapLoaderFromArray>();

        // Create FileReader object
        fr = new FileReader();

        // Read maps from file
        ReadMapsFromFile();
    }

    /// <summary>
    /// Reads every map from a file
    /// </summary>
    private void ReadMapsFromFile()
    {
        // ----- READ FILE -----

        string fileName = "FixedMaps";

        // Read text file using FileReader class
        string fileContent = fr.ReadFile(fileName);

        // Split every line from text
        string[] fileLines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        // ----- VALIDATE CORRECT NUMBER OF ROWS -----

        // Count number of maps
        int totalMaps = 1;
        for (int i = 0; i < fileLines.Length; i++)
        {
            if (fileLines[i].CompareTo("") == 0)
            {
                totalMaps++;
            }
        }

        //Console.WriteLine("Total maps: " + totalMaps);
        //Console.WriteLine("Rows per map: " + (fileLines.Length - totalMaps + 1) / totalMaps);

        // Validate correct number of rows
        if ((fileLines.Length - totalMaps + 1) / totalMaps != rowSize)
        {
            Debug.Log("Rows per map (" + (fileLines.Length - totalMaps + 1) / totalMaps + ") should be " + rowSize);
            Debug.Log("Hint: Remember to not add a newline at the end of final map");
            return;
        }

        // ----- GET REAL MAP VALUES -----

        // Store real map rows on mapLines array, storing each map separately
        string[][] mapLines = new string[totalMaps][];
        int map = 0;
        int row = 0;
        mapLines[map] = new string[rowSize];
        for (int i = 0; i < fileLines.Length; i++)
        {
            if (fileLines[i].CompareTo("") != 0)
            {
                mapLines[map][row] = fileLines[i];
                row++;
            }
            else
            {
                map++;
                row = 0;
                mapLines[map] = new string[rowSize];
            }
        }

        // Get real map values
        logicalMaps = new char[totalMaps][][];
        for (map = 0; map < mapLines.Length; map++)
        {
            logicalMaps[map] = new char[rowSize][];
            for (row = 0; row < rowSize; row++)
            {
                // Get real values
                logicalMaps[map][row] = mapLines[map][row].ToCharArray();

                // Validate correct number of columns
                if (logicalMaps[map][row].Length != colSize)
                {
                    Debug.Log("Rows per map (" + logicalMaps[map][row].Length + ") should be " + colSize);
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Loads a random map and enables it on game
    /// </summary>
    public override void LoadMap()
    {
        // Get random between 0-totalMaps
        int randomMap = UnityEngine.Random.Range(0, logicalMaps.Length);

        // Load real map
        realMapLoader.LoadMap(logicalMaps[randomMap], 'x');
    }

    /// <summary>
    /// Disables current map
    /// </summary>
    public override void DisableMap()
    {
        realMapLoader.DisableMap();
    }
}

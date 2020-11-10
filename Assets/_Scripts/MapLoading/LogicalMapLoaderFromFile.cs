using UnityEngine;
using System;

// This class loads random maps from a .txt file.
public class LogicalMapLoaderFromFile : LogicalMapLoader
{
    private System.Random rand;
    private FileReader fr;

    void Awake()
    {
        rand = new System.Random();

        fr = new FileReader();

        InitializeLogicalMaps();
    }

    // Implements the LogicalMaps initialization by reading the maps from a file
    public override void InitializeLogicalMaps()
    {
        ReadMapsFromFile();
    }

    // Reads file and stores every map on LogicalMaps
    private void ReadMapsFromFile()
    {
        // ----- READ FILE -----

        string fileName = "FixedMaps";

        // Read text file using FileReader class
        string fileContent = fr.ReadFile(fileName);

        // Split every line from text
        string[] fileLines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        // Count number of maps
        int totalMaps = 1;
        for (int i = 0; i < fileLines.Length; i++)
        {
            if (fileLines[i].CompareTo("") == 0)
            {
                totalMaps++;
            }
        }

        // ----- GET REAL MAP VALUES -----

        // Store real map rows on mapLines array, storing each map separately
        string[][] mapLines = new string[totalMaps][];
        int map = 0;
        int row = 0;

        // Count number of rows and initialize the second dimention of mapLine's array
        for (int i = 0; i < fileLines.Length; i++)
        {
            if (fileLines[i].CompareTo("") != 0)
            {
                row++;
            }
            else
            {
                mapLines[map] = new string[row];
                map++;
                row = 0;
            }
        }
        mapLines[map] = new string[row];

        map = 0;
        row = 0;
        // Store real map rows on mapLines array
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
            }
        }

        // Get real map values
        LogicalMaps = new char[totalMaps][][];
        for (map = 0; map < mapLines.Length; map++)
        {
            int rowSize = mapLines[map].Length;

            LogicalMaps[map] = new char[rowSize][];
            for (row = 0; row < rowSize; row++)
            {
                // Get real values
                LogicalMaps[map][row] = mapLines[map][row].ToCharArray();
            }
        }
    }

    // Returns a random map from the previously read ones
    public override char[][] LoadLogicalMap()
    {
        int randomMap = rand.Next(0, LogicalMaps.Length);

        return LogicalMaps[randomMap];
    }
}

using UnityEngine;
/// <summary>
/// This interface defines the methods for loading and disabling maps.
/// </summary>
public abstract class LogicalMapLoader : MonoBehaviour
{
    //TODO describe variable in XML comment
    public char[][][] LogicalMaps { get; set; }

    /*
    private int totalMaps;
    public int TotalMaps { get; }

    private int rowSize;
    public int RowSize { get; }

    private int colSize;
    public int ColSize { get; }
    */

    private int totalMaps;
    public int TotalMaps
    {
        get { return totalMaps; }
    }

    private int rowSize;
    public int RowSize
    {
        get { return rowSize; }
    }

    private int colSize;
    public int ColSize
    {
        get { return colSize; }
    }


    public void InitializeMapLoader(int totalMaps, int totalRows, int totalColumns)
    {
        this.totalMaps = totalMaps;
        rowSize = totalRows;
        colSize = totalColumns;

        // Set size of logicalMap
        LogicalMaps = new char[totalMaps][][];
        for (int i = 0; i < totalMaps; i++)
        {
            LogicalMaps[i] = new char[rowSize][];
            for (int j = 0; j < rowSize; j++)
            {
                LogicalMaps[i][j] = new char[colSize];
            }
        }
    }

    public void InitializeMapLoader2(int totalMaps, int totalRows, int totalColumns)
    {
        this.totalMaps = totalMaps;
        rowSize = totalRows;
        colSize = totalColumns;
    }

    /// <summary>
    /// Returns map from given map index
    /// </summary>
    public abstract char[][] LoadLogicalMap();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class loads a GameObject map from a given char array.
/// </summary>
public class RealMapLoaderFromArray : MonoBehaviour
{
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
    }

    /// <summary>
    /// Initializes the map's parent
    /// </summary>
    private void InitializeMapParent()
    {
        map = new GameObject("Current Map");
        map.gameObject.transform.position = mapOrigin;
    }

    /// <summary>
    /// Initializes the wall pool
    /// </summary>
    private void InitializeWallPool()
    {
        // Initialize pool
        int poolSize = 128;
        wallPool = GetComponent<GameObjectPoolSystem>();
        wallPool.InitializePool(wallPrefab, poolSize, map.transform);
    }

    /// <summary>
    /// Gets the horizontal and vertical dimentions from the wall prefab
    /// </summary>
    private void GetWallDimentions()
    {
        wallWidth = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        wallHeight = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    /// <summary>
    /// Loads a map by transforming a given char array to a GameObject, and enables it on game.
    /// </summary>
    /// <param name="logicalMap">The map represented in a char array</param>
    /// <param name="wallType">The char value that represents a map wall</param>
    public void LoadMap(char[][] logicalMap, char wallType)
    {
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

    /// <summary>
    /// Disables the parent map and every single wall in the pool
    /// </summary>
    public void DisableMap()
    {
        map.SetActive(false);
        wallPool.DisableObjectsInPool();
    }
}
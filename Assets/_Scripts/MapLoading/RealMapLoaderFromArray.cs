using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMapLoaderFromArray : MonoBehaviour
{
    GameObject map;
    private GameObjectPoolSystem wallPool;

    [SerializeField] private GameObject wallPrefab = null;
    [SerializeField] private Vector3 firstWallPosition = Vector3.zero;
    private Vector3 mapOrigin = Vector3.zero;

    private float wallWidth;
    private float wallHeight;

    void Awake()
    {
        // Initialize wall pool
        InitializeWallPool();

        // Get wall dimentions
        GetWallDimentions();

        // Set object at position zero (because current transform will be parent to the walls)
        transform.position = Vector3.zero;
    }

    private void GetWallDimentions()
    {
        // Get dimensions
        wallWidth = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        wallHeight = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void InitializeWallPool()
    {
        int poolSize = 128;
        map = new GameObject("Current Map");
        map.gameObject.transform.position = mapOrigin;

        wallPool = GetComponent<GameObjectPoolSystem>();
        wallPool.InitializePool(wallPrefab, poolSize, map.transform);
    }

    /// <summary>
    /// Transforms a map from the given char[][] to a game object and enables it on game
    /// </summary>
    /// <param name="logicalMap">The map represented in a char array</param>
    /// <param name="wallType">The char value that represents a map wall</param>
    public void LoadMap(char[][] logicalMap, char wallType)
    {
        // Enable map
        map.SetActive(true);

        // Initialize current wall position
        Vector3 pos = new Vector3(firstWallPosition.x, firstWallPosition.y, firstWallPosition.z);

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
    /// Disables the map game object
    /// </summary>
    public void DisableMap()
    {
        // Disables the main object
        map.SetActive(false);
        // Disables every object from the map
        wallPool.DisableObjectsInPool();
    }
}
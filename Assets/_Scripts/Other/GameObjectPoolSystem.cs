using UnityEngine;

/// <summary>
/// This class handles a GameObject pool by disabling it and enabling it when needed.
/// </summary>
public class GameObjectPoolSystem : MonoBehaviour
{
    private GameObject[] objectPool;

    /// <summary>
    /// Initializes the GameObject pool
    /// </summary>
    /// <param name="prefab">Object to be stored in the pool</param>
    /// <param name="poolSize">Size of pool</param>
    /// <param name="parent">Objects' parent</param>
    public void InitializePool(GameObject prefab, int poolSize, Transform parent = null)
    {
        // Set pool size
        objectPool = new GameObject[poolSize];

        // Initialize objects
        for (int i = 0; i < poolSize; i++)
        {
            objectPool[i] = Instantiate(prefab);
            objectPool[i].SetActive(false);
            objectPool[i].transform.parent = parent;
        }
    }

    /// <summary>
    /// Disables objects in pool
    /// </summary>
    public void DisableObjectsInPool()
    {
        for (int i = 0; i < objectPool.Length; i++)
        {
            if (objectPool[i].activeSelf)
            {
                objectPool[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Enables a pool GameObject
    /// </summary>
    /// <param name="position">Position to place new GameObject</param>
    public void EnableObject(Vector3 position)
    {
        for (int i = 0; i < objectPool.Length; i++)
        {
            if (!objectPool[i].activeSelf)
            {
                objectPool[i].transform.position = position;
                objectPool[i].SetActive(true);
                break;
            }
        }
    }
}

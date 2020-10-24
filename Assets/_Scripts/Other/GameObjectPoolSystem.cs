using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolSystem : MonoBehaviour
{
    private GameObject[] objectPool;

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

    public void DisableObjectsInPool()
    {
        for (int i = 0; i < objectPool.Length; i++)
        {
            objectPool[i].SetActive(false);
        }
    }

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

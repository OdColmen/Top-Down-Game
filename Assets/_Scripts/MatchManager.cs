using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public delegate void GameOver_EventHandler(bool success);
    public event GameOver_EventHandler GameOver;

    [SerializeField] private GameObject[] items = null;
    [SerializeField] private GameObject[] enemies = null;

    void Awake()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<ItemCollisionSystem>().CollidedWithHero += CollectItem;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyCollisionSystem>().CollidedWithHero += Die;
        }
    }

    public void StartMatch()
    {
        EnableNpcs();
    }

    public void StopMatch()
    {
        DisableNpcs();
    }

    private void EnableNpcs()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(true);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    private void DisableNpcs()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }

    private void CollectItem(GameObject itemCollected)
    {
        // Collect (disable) item
        itemCollected.SetActive(false);

        // Check if all items were collected
        bool allItemsWereCollected = true;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].activeSelf)
            {
                allItemsWereCollected = false;
            }
        }

        if (allItemsWereCollected)
        {
            // Fire succesful game over
            GameOver?.Invoke(true);
        }
    }

    private void Die()
    {
        // Fire unsuccesful game over
        GameOver?.Invoke(false);
    }
}
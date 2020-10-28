using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public delegate void GameOver_EventHandler(bool mapWasCleared);
    public event GameOver_EventHandler GameOver;

    [SerializeField] private GameObject hero = null;
    [SerializeField] private GameObject[] items = null;
    [SerializeField] private GameObject[] enemies = null;

    private Vector3 initialPositionHero;
    private Vector3[] initialPositionItems;
    private Vector3[] initialPositionEnemies;

    void Awake()
    {
        initialPositionHero = hero.transform.position;

        initialPositionItems = new Vector3[items.Length];
        initialPositionEnemies = new Vector3[enemies.Length];

        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<ItemCollisionSystem>().CollidedWithHero += CollectItem;
            initialPositionItems[i] = items[i].transform.position;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyCollisionSystem>().CollidedWithHero += Die;
            initialPositionEnemies[i] = enemies[i].transform.position;
        }
    }

    /// <summary>
    /// Starts match by enabling all the characters
    /// </summary>
    public void StartMatch()
    {
        EnableCharacters();
    }

    /// <summary>
    /// Stops match by disabling all the characters
    /// </summary>
    public void StopMatch()
    {
        DisableCharacters();
    }

    /// <summary>
    /// Enables hero, items and enemies
    /// </summary>
    private void EnableCharacters()
    {
        hero.SetActive(true);
        hero.transform.position = initialPositionHero;

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(true);
            items[i].transform.position = initialPositionItems[i];
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
            enemies[i].transform.position = initialPositionEnemies[i];
        }
    }

    /// <summary>
    /// Disables hero, items and enemies
    /// </summary>
    private void DisableCharacters()
    {
        hero.SetActive(false);

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }

    /// <summary>
    /// Collects an item, and invokes the game over event if all items were collected
    /// </summary>
    /// <param name="itemCollected">GameObject of the item to collect</param>
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

    /// <summary>
    /// Invokes the game over event
    /// </summary>
    private void Die()
    {
        // Fire unsuccesful game over
        GameOver?.Invoke(false);
    }
}
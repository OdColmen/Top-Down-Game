using UnityEngine;

/// <summary>
/// This class manages the hero and NPC GameObjects, the item collection logic,
/// and invokes the GameOver event.
/// </summary>
public class MatchManager : MonoBehaviour
{
    public delegate void GameOverEventHandler(bool mapWasCleared);
    /// <summary>
    /// It's invoked when the player wins or loses a match.
    /// </summary>
    public event GameOverEventHandler GameOver;

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
    /// Starts a new match by enabling all the characters
    /// </summary>
    public void StartMatch()
    {
        EnableCharacters();
    }

    /// <summary>
    /// Stops current match by disabling all the characters
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
    /// Collects an item, and invokes the Game Over event if all items were collected
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
            GameOver?.Invoke(true);
        }
    }

    /// <summary>
    /// Invokes the Game Over event. Intented to be used when the map was not cleared.
    /// </summary>
    private void Die()
    {
        GameOver?.Invoke(false);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<ItemCollisionSystem>().CollidedWithHero -= CollectItem;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyCollisionSystem>().CollidedWithHero -= Die;
        }
    }
}
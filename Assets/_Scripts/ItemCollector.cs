using UnityEngine;

/// <summary>
/// This class handles the item collection logic, and fires an event when all items were collected.
/// </summary>
class ItemCollector : MonoBehaviour
{
    public delegate void AllItemsWereCollected_EventHandler();
    /// <summary>
    /// It's invoked when all items are collected in a match.
    /// </summary>
    public event AllItemsWereCollected_EventHandler AllItemsWereCollected;

    [SerializeField] private GameObject[] items = null;
    
    /// <summary>
    /// Subscribes each item's collision system to the CollidedWithHero event
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject += CollectItem;
        }
    }

    /// <summary>
    /// Collects an item, and invokes an event if all items were collected
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
            AllItemsWereCollected?.Invoke();
        }
    }

    /// <summary>
    /// Unsubscribes each item's collision system to the CollidedWithHero event
    /// </summary>
    private void OnDestroy()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                items[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject -= CollectItem;
            }
        }
    }
}
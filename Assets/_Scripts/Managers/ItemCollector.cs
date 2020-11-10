using UnityEngine;

// This class handles the item collection logic, and fires an event when all items were collected.
class ItemCollector : MonoBehaviour
{
    public delegate void AllItemsWereCollected_EventHandler();
    public event AllItemsWereCollected_EventHandler AllItemsWereCollected;

    [SerializeField] private GameObject[] items = null;
    
    private void Awake()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject += CollectItem;
        }
    }

    // Collects an item, and invokes an event if all items were collected
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
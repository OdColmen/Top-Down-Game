using UnityEngine;

class HealthManager : MonoBehaviour
{
    public delegate void HealthReachedZeroEventHandler();
    /// <summary>
    /// It's invoked when the [player] health reaches zero in a match.
    /// </summary>
    public event HealthReachedZeroEventHandler HealthReachedZero;

    [SerializeField] private int initialHealth = 1;
    private int health;

    [SerializeField] private GameObject[] enemies = null;

    /// <summary>
    /// Subscribes each enemy to the CollidedWithHero event
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyCollisionSystem>().CollidedWithHero += ReduceHealth;
        }
    }

    /// <summary>
    /// Restores health back ot its initial value
    /// </summary>
    public void RestoreHealth()
    {
        health = initialHealth;
    }

    /// <summary>
    /// Collects an item, and invokes the Game Over event if all items were collected
    /// </summary>
    private void ReduceHealth(GameObject enemyThatAttacked)
    {
        // Disable enemy
        enemyThatAttacked.SetActive(false);

        health--;
        
        if (health <= 0)
        {
            HealthReachedZero?.Invoke();
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<EnemyCollisionSystem>().CollidedWithHero -= ReduceHealth;
            }
        }
    }
}
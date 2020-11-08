using UnityEngine;

/// <summary>
/// This class handles the player health, reducing it and restoring it when needed.
/// It also calls an event when health reaches zero.
/// </summary>
class HealthManager : MonoBehaviour
{
    public delegate void HealthReachedZero_EventHandler();
    /// <summary>
    /// It's invoked when the [player] health reaches zero in a match.
    /// </summary>
    public event HealthReachedZero_EventHandler HealthReachedZero;

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
            enemies[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject += ReduceHealth;
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
    /// Reduces health, and invokes an event if the health reaches zero
    /// </summary>
    /// <param name="enemyThatHitHero">GameObject of the enemy that hit the hero</param>
    private void ReduceHealth(GameObject enemyThatHitHero)
    {
        // Disable enemy
        enemyThatHitHero.SetActive(false);

        health--;
        
        if (health <= 0)
        {
            HealthReachedZero?.Invoke();
        }
    }

    /// <summary>
    /// Unsubscribes each enemy to the CollidedWithHero event
    /// </summary>
    private void OnDestroy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject -= ReduceHealth;
            }
        }
    }
}
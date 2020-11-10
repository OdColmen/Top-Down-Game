using UnityEngine;

// This class handles the player health, reducing it and restoring it when needed.
// It also calls an event when health reaches zero.
class HealthManager : MonoBehaviour
{
    public delegate void HealthReachedZero_EventHandler();
    public event HealthReachedZero_EventHandler HealthReachedZero;

    [SerializeField] private int initialHealth = 1;
    private int health;

    [SerializeField] private GameObject[] enemies = null;

    private void Awake()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject += ReduceHealth;
        }
    }

    public void RestoreHealth()
    {
        health = initialHealth;
    }

    // Reduces health, disables the enemy that hit the hero,
    // and invokes an event if the health reaches zero
    private void ReduceHealth(GameObject enemyThatHitHero)
    {
        enemyThatHitHero.SetActive(false);

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
                enemies[i].GetComponent<CollisionSystemWithObjectInfo>().CollidedWithGivenObject -= ReduceHealth;
            }
        }
    }
}
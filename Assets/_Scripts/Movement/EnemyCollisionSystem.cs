using UnityEngine;

/// <summary>
/// This class detects the collision between enemies and the hero
/// </summary>
public class EnemyCollisionSystem : NpcCollisionSystem
{
    public delegate void CollidedWithHero_EventHandler();
    /// <summary>
    /// It's invoked when an enemy collides with the hero.
    /// </summary>
    public event CollidedWithHero_EventHandler CollidedWithHero;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        // Check collision with every object
        base.OnCollisionEnter2D(col);

        // Invoke an event if collision is against hero
        if (col.gameObject.CompareTag("Hero"))
        {
            CollidedWithHero?.Invoke();
        }
    }
}

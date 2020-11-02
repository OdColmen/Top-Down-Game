using UnityEngine;

/// <summary>
/// This class detects the collision between NPCs and other objects
/// </summary>
public class NpcCollisionSystem : MonoBehaviour
{
    public delegate void CollidedWithAnythingEventHandler();
    /// <summary>
    /// It's invoked when an NPC collides with any gameplay object.
    /// </summary>
    public event CollidedWithAnythingEventHandler CollidedWithAnything;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        // Invoke an event if collision is against any gameplay object (besides the hero)
        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Item")
            || col.gameObject.CompareTag("Enemy"))
        {
            CollidedWithAnything?.Invoke();
        }
    }
}

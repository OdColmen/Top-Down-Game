using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class detects the collision between NPCs and other objects
/// </summary>
public class NpcCollisionSystem : MonoBehaviour
{
    public delegate void CollidedWithAnything_EventHandler();
    /// <summary>
    /// It's invoked when an NPC collides with any gameplay object.
    /// </summary>
    public event CollidedWithAnything_EventHandler CollidedWithAnything;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        // Invoke an event if collision is against any gameplay object
        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Item")
            || col.gameObject.CompareTag("Enemy"))
        {
            CollidedWithAnything?.Invoke();
        }
    }
}

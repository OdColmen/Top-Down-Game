﻿using UnityEngine;

/// <summary>
/// This class detects the collision between items and the hero
/// </summary>
public class ItemCollisionSystem : MonoBehaviour
{
    public delegate void CollidedWithHero_EventHandler(GameObject obj);
    /// <summary>
    /// It's invoked when an item collides with the hero.
    /// </summary>
    public event CollidedWithHero_EventHandler CollidedWithHero;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        // Invoke an event if collision is against hero
        if (col.gameObject.CompareTag("Hero"))
        {
            CollidedWithHero?.Invoke(gameObject);
        }
    }
}

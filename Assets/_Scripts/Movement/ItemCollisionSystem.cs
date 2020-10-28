using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionSystem : NpcCollisionSystem
{
    public delegate void CollidedWithHero_EventHandler(GameObject obj);
    public event CollidedWithHero_EventHandler CollidedWithHero;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        // Check collision with every objects
        base.OnCollisionEnter2D(col);

        // Invoke an event if collision is against hero
        if (col.gameObject.CompareTag("Hero"))
        {
            CollidedWithHero?.Invoke(gameObject);
        }
    }
}

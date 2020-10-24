using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionSystem : NpcCollisionSystem
{
    public delegate void CollidedWithHero_EventHandler();
    public event CollidedWithHero_EventHandler CollidedWithHero;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);

        // Colision item->hero
        //if (gameObject.CompareTag("Item") && col.gameObject.CompareTag("Hero"))
        if (col.gameObject.CompareTag("Hero"))
        {
            CollidedWithHero?.Invoke();
        }
    }
}

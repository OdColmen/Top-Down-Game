using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollisionSystem : MonoBehaviour
{
    public delegate void CollidedWithWall_EventHandler();
    public event CollidedWithWall_EventHandler CollidedWithWall;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        // Colision npc->wall
        //if (gameObject.CompareTag("Item") && col.gameObject.CompareTag("Wall"))
        if (col.gameObject.CompareTag("Wall"))
        {
            CollidedWithWall?.Invoke();
        }
    }
}

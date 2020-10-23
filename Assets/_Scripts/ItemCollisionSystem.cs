using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionSystem : MonoBehaviour
{
    public delegate void ItemCollidedWithWall_EventHandler();
    public event ItemCollidedWithWall_EventHandler ItemCollidedWithWall;

    public void OnCollisionEnter2D(Collision2D col)
    {
        // Colision item->wall
        if (gameObject.CompareTag("Item") && col.gameObject.CompareTag("Wall"))
        {
            ItemCollidedWithWall?.Invoke();
        }
    }
}

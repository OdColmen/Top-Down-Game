using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollisionSystem : MonoBehaviour
{
    public delegate void CollidedWithWall_EventHandler();
    public event CollidedWithWall_EventHandler CollidedWithAnything;

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

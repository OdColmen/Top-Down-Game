﻿using UnityEngine;

// This class detects the collision between attached GameObject and GameObjects with given tag.
// Its fired event has no parameters (it does not send information about the collider game object)
public class CollisionSystemWithoutObjectInfo : MonoBehaviour
{
    [SerializeField] private string[] tagsToCheck = null;

    // This event is invoked when the attached GameObject collides with GameObjects of given tag.
    public delegate void CollidedWithSomething_EventHandler();
    public event CollidedWithSomething_EventHandler CollidedWithSomething;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        // Check every tag
        for (int i = 0; i < tagsToCheck.Length; i++)
        {
            // Check collision
            if (col.gameObject.CompareTag(tagsToCheck[i]))
            {
                // Invoke event
                CollidedWithSomething?.Invoke();
            }
        }
    }
}

using UnityEngine;

/// <summary>
/// This class detects the collision between attached GameObject and GameObjects with give tag.
/// Its fired event does send information about the collider game object
/// </summary>
public class CollisionSystemWithObjectInfo : MonoBehaviour
{
    [SerializeField] private string[] tagsToCheck = null;

    public delegate void CollidedWithGivenObject_EventHandler(GameObject obj);
    /// <summary>
    /// It's invoked when the attached GameObject collides with GameObjects of given tag.
    /// </summary>
    public event CollidedWithGivenObject_EventHandler CollidedWithGivenObject;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        // Check every tag
        for (int i = 0; i < tagsToCheck.Length; i++)
        {
            // Check collision
            if (col.gameObject.CompareTag(tagsToCheck[i]))
            {
                // Invoke event
                CollidedWithGivenObject?.Invoke(gameObject);
            }
        }
    }
}

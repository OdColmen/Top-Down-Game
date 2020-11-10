using UnityEngine;

// This class detects the collision between attached GameObject and GameObjects with give tag.
// Its fired event does send information about the collider game object
public class CollisionSystemWithObjectInfo : MonoBehaviour
{
    [SerializeField] private string[] tagsToCheck = null;

    // This event is invoked when the attached GameObject collides with GameObjects of given tag.
    public delegate void CollidedWithGivenObject_EventHandler(GameObject obj);
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

using UnityEngine;

// Required Components
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CollisionSystemWithoutObjectInfo))]

/// <summary>
/// This class randomly sets a new direction for the game NPCs.
/// It passes the new direction to the CharacterMovement's Move method.
/// </summary>
public class NpcRandomInput : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private CollisionSystemWithoutObjectInfo collisions;

    private Vector3 direction;

    void Awake()
    {
        // Initialize random
        Random.InitState((int)System.DateTime.Now.Ticks);

        // Get components
        characterMovement = GetComponent<CharacterMovement>();
        collisions = GetComponent<CollisionSystemWithoutObjectInfo>();

        // Subscribe to "ItemCollidedWithAnything" event
        collisions.CollidedWithSomething += SetNewDirection;
    }

    void OnEnable()
    {
        SetNewDirection();
    }

    void Update()
    {
        characterMovement.Move(direction);
    }

    /// <summary>
    /// Randomly sets a new direction for the game object
    /// </summary>
    public void SetNewDirection()
    {
        int random = Random.Range(0, 8);

        // Choose one of 8 possible directions and set it as the new one
        switch (random)
        {
            case 0:
                direction = Vector3.up;
                break;
            case 1:
                direction = Vector3.right;
                break;
            case 2:
                direction = Vector3.down;
                break;
            case 3:
                direction = Vector3.left;
                break;
            case 4:
                direction = new Vector3(1, 1, 0);
                direction.Normalize();
                break;
            case 5:
                direction = new Vector3(1, -1, 0);
                direction.Normalize();
                break;
            case 6:
                direction = new Vector3(-1, -1, 0);
                direction.Normalize();
                break;
            default:
                direction = new Vector3(-1, 1, 0);
                direction.Normalize();
                break;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to "ItemCollidedWithAnything" event
        collisions.CollidedWithSomething -= SetNewDirection;
    }
}

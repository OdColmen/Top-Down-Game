using UnityEngine;

// Required Components
[RequireComponent(typeof(CollisionSystemWithoutObjectInfo))]

// This class randomly sets a new direction for the game NPCs.
public class NpcRandomInput : CharacterDirectionalInput
{
    private CollisionSystemWithoutObjectInfo collisions;

    void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        collisions = GetComponent<CollisionSystemWithoutObjectInfo>();

        collisions.CollidedWithSomething += GetDirectionalInput;
    }

    void OnEnable()
    {
        GetDirectionalInput();
    }

    // Randomly sets a new direction for the game object
    public override void GetDirectionalInput()
    {
        int random = Random.Range(0, 8);

        // Choose one of 8 possible directions and set it as the new one
        switch (random)
        {
            case 0:
                CurrentDirection = Vector3.up;
                break;
            case 1:
                CurrentDirection = Vector3.right;
                break;
            case 2:
                CurrentDirection = Vector3.down;
                break;
            case 3:
                CurrentDirection = Vector3.left;
                break;
            case 4:
                CurrentDirection = new Vector3(1, 1, 0);
                CurrentDirection.Normalize();
                break;
            case 5:
                CurrentDirection = new Vector3(1, -1, 0);
                CurrentDirection.Normalize();
                break;
            case 6:
                CurrentDirection = new Vector3(-1, -1, 0);
                CurrentDirection.Normalize();
                break;
            default:
                CurrentDirection = new Vector3(-1, 1, 0);
                CurrentDirection.Normalize();
                break;
        }
    }

    private void OnDestroy()
    {
        collisions.CollidedWithSomething -= GetDirectionalInput;
    }
}

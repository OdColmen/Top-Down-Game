using UnityEngine;

// Required Components
[RequireComponent(typeof(CharacterMovement))]

// This class handles the player input and sets the direction of the hero movement.
// It passes the new direction to the CharacterMovement's Move method.
public class PlayerInput : MonoBehaviour
{
    private CharacterMovement characterMovement;

    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        // Get direction from player
        Vector3 direction = GetPlayerDirectionInput();

        // Move character
        characterMovement.Move(direction);
    }

    private Vector3 GetPlayerDirectionInput()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(directionX, directionY, 0);

        // Normalize direction ONLY if the magnitude is > 1 (.sgrMagnitude is faster than .magnitude)
        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        return direction;
    }
}

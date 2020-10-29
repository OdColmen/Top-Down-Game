using UnityEngine;

// Required Components
[RequireComponent(typeof(CharacterMovement))]

/// <summary>
/// This class handles the player input and sets the direction of the hero movement.
/// It passes the new direction to the CharacterMovement's Move method.
/// </summary>
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

    /// <summary>
    /// Reads the player directional input
    /// </summary>
    /// <returns>Input direction normalized</returns>
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

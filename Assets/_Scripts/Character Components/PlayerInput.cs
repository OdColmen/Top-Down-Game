using UnityEngine;

// This class handles the player input and sets the direction of the hero movement.
public class PlayerInput : CharacterDirectionalInput
{
    void Update()
    {
        // Get direction from player
        GetDirectionalInput();
    }

    public override void GetDirectionalInput()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        CurrentDirection = new Vector3(directionX, directionY, 0);

        // Normalize direction ONLY if the magnitude is > 1 (.sgrMagnitude is faster than .magnitude)
        if (CurrentDirection.sqrMagnitude > 1)
        {
            CurrentDirection.Normalize();
        }
    }
}

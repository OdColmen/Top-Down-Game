using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Required Components
[RequireComponent(typeof(CharacterMovement))]

public class PlayerInput : MonoBehaviour
{
    private CharacterMovement characterMovement;

    void Awake()
    {
        // Get Character Movement component
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
        // Get x and y axis
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        //Debug.Log("dir x: " + directionX + " dir y: " + directionY);

        // Set movement direction
        Vector3 direction = new Vector3(directionX, directionY, 0);

        // Normalize direction ONLY if the magnitude is > 1 (.sgrMagnitude is faster than .magnitude)
        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        return direction;
    }
}

﻿using UnityEngine;

// Required Components
[RequireComponent(typeof(CharacterDirectionalInput))]

// This class moves the attached rigid body given a Vector3 direction.
public class CharacterMovement : MonoBehaviour
{
    CharacterDirectionalInput characterInput;

    public float speed = 50.0f;
    
    private Rigidbody2D myRigidbody;
    private Vector3 previousDirection = Vector3.zero;
    
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        characterInput = GetComponent<CharacterDirectionalInput>();
    }

    private void Update()
    {
        Move(characterInput.CurrentDirection);
    }

    // Moves the game object by changing the rigidbody's velocity, and rotates by setting the transform's up property.
    // It rotates ONLY if the direction vector is big enough (This prevents the object from looking only
    // at one of the 4 main directions when movement stops)
    private void Move(Vector3 direction)
    {
        // Move
        myRigidbody.velocity = direction * speed;

        // Rotate only if movement is big enough
        if (direction.sqrMagnitude > 0.2)
        {
            transform.up = direction;
            previousDirection = transform.up;
        }
        // Keep previous direction
        else
        {
            transform.up = previousDirection;
        }
    }
}

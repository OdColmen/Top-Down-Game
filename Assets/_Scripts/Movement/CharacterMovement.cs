using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 50.0f;
    
    private Rigidbody2D myRigidbody;
    private Vector3 previousDirection = Vector3.zero;
    
    void Awake()
    {
        // Get Rigidbody2D component
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Move game object by changing the rigidbody velocity, and rotate by setting the transform's up property
    // Rotate ONLY if the direction vector is big enough (This prevents the object from looking only
    // at one of the 4 main directions when movement stops)
    public void Move(Vector3 direction)
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

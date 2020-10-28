﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// Required Components
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(NpcCollisionSystem))]

public class NpcRandomInput : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private NpcCollisionSystem collisions;

    private Vector3 direction;

    void Awake()
    {
        // Initialize random
        Random.InitState((int)System.DateTime.Now.Ticks);

        // Get CharacterMovement component
        characterMovement = GetComponent<CharacterMovement>();

        // Get ItemCollisionSystem component
        collisions = GetComponent<NpcCollisionSystem>();

        // Subscribe to "ItemCollidedWithAnything" event
        collisions.CollidedWithAnything += SetNewDirection;
    }

    void OnEnable()
    {
        // Set new direction when enabling current object
        SetNewDirection();
    }

    void Update()
    {
        // Move character
        characterMovement.Move(direction);
    }

    /// <summary>
    /// Randomly sets a new direction for the game object
    /// </summary>
    public void SetNewDirection()
    {
        // Get random between 0-7
        int random = Random.Range(0, 8);

        // Choose one of 8 possible directions and set it as the new direction
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
}
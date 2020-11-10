using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This abstract class defines the members for loading logical maps in char arrays,
// so they can be transformed into real GameObject maps somewhere else
public abstract class CharacterDirectionalInput : MonoBehaviour
{
    public Vector3 CurrentDirection { get; set; }

    public abstract void GetDirectionalInput();
}

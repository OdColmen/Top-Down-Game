using UnityEngine;

// This class sets the initial position of the attached GameObject, on enable
class InitialPositionSetter : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnEnable()
    {
        transform.position = this.initialPosition;
    }
}

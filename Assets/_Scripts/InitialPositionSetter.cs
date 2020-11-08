using UnityEngine;

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

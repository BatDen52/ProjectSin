using UnityEngine;

public class BackMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _loopValue;

    private void Update()
    {
        transform.position += Vector3.up * (-_speed) * Time.deltaTime;

        if (transform.position.y < _loopValue)
            transform.position = Vector3.zero;
    }
}

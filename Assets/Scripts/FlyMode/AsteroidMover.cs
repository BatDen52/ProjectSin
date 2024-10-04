using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}

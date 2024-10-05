using UnityEngine;

public class FlyerMover : MonoBehaviour
{
    [SerializeField] private FlyDirection _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _step;
    [SerializeField] private float _minCordinate;
    [SerializeField] private float _maxCordinate;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_direction == FlyDirection.X)
        {
            if (Input.GetKey(KeyCode.D) /*&& _targetPosition.x < _maxCordinate*/)
                _targetPosition.x = _maxCordinate;
            else if (Input.GetKey(KeyCode.A)/* && _targetPosition.x > _minCordinate*/)
                _targetPosition.x = _minCordinate;
            else
                return;
        }
        else if (_direction == FlyDirection.Y)
        {
            if (Input.GetKey(KeyCode.W) /*&& _targetPosition.x < _maxCordinate*/)
                _targetPosition.y = _maxCordinate;
            else if (Input.GetKey(KeyCode.S) /*&& _targetPosition.x > _minCordinate*/)
                _targetPosition.y = _minCordinate;
            else
                return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}

enum FlyDirection { X, Y }
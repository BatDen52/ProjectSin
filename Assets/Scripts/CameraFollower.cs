using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothCoefficient;

    [SerializeField] private Vector3 _offset;

    [field: SerializeField] public bool IsFollow { get; private set; } = true;
    public Vector3 Offset => _offset;

    public static CameraFollower Instance;

    private void Awake()
    {
        Instance = this;
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        if (IsFollow)
            SmoothFollow();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Follow()
    {
        IsFollow = true;
    }

    public void StopFollow()
    {
        IsFollow = false;
    }

    public void SetOffsetY(float offset)
    {
        _offset.y = offset;
    }

    private void SmoothFollow()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothCoefficient);
    }
}

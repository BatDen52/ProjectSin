using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothCoefficient;

    private Vector3 _offset;

    public bool IsFollow { get; private set; } = true;

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

    private void SmoothFollow()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothCoefficient);
    }
}

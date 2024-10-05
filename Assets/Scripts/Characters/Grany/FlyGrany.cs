using System;
using UnityEngine;

[RequireComponent(typeof(Fliper))]
public class FlyGrany : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _stopDistance = 7f;

    private Transform _target;
    private Fliper _fliper;

    private void Awake()
    {
        _fliper = GetComponent<Fliper>();
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(transform.position - _target.position) > _stopDistance * _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            _fliper.LookAtTarget(_target.position);
        }
    }

    public void Init(Transform target)
    {
        _target = target;
        _fliper.Initialize(_target);
    }

    public void Push(Vector3 position, float pushForce)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
        rigidbody.AddForce((transform.position - position).normalized * pushForce);
    }
}
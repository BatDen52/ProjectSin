using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FalledLetter : MonoBehaviour
{
    public event Action<FalledLetter> Falled;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DeadZone>(out _))
            Falled.Invoke(this);
    }
}

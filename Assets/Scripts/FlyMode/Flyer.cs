using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Flyer : MonoBehaviour
{
    [SerializeField] private int _healthPoints;

    private CollisionHandler _collisionHandler;

    public event Action Died;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.BonusFounded += OnBonusFounded;
    }

    private void OnDisable()
    {
        _collisionHandler.BonusFounded -= OnBonusFounded;
    }

    public void TakeDamage(int damage)
    {
        _healthPoints-= damage;

        if (_healthPoints <= 0)
            Died?.Invoke();
    }

    public void OnBonusFounded(LightBonus bonus)
    {
        bonus.Collect();
    }
}

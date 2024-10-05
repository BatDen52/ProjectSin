using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CollisionHandler))]
public class Flyer : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _neededScore = 6;
    [SerializeField] private float _outerAdded = 0.5f;
    [SerializeField] private float _innerAdded = 0.5f;

    private CollisionHandler _collisionHandler;
    private int _score = 0;

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
        _healthPoints -= damage;

        if (_healthPoints <= 0)
            Died?.Invoke();
    }

    public void OnBonusFounded(LightBonus bonus)
    {
        bonus.Collect();

        _score++;

        _light.pointLightOuterRadius += _outerAdded;
        _light.pointLightInnerRadius += _innerAdded;

        if (_score >= _neededScore)
        {
            _collisionHandler.enabled = false;
            FlyModSpawner.Instance.StopSpawning();
            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        transform.DOMove(transform.position + Vector3.up * 20, 2.5f);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(0);
    }
}

using System;
using UnityEngine;

public class BlockFirstLightTrigget : MonoBehaviour
{
    [SerializeField] private SoulsLight _light;
    [SerializeField] private GameObject[] _walls;

    private void OnEnable()
    {
        _light.Collected += OnCollected;
    }

    private void OnDisable()
    {
        _light.Collected -= OnCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        foreach (var wall in _walls)
            wall.SetActive(true);
    }

    private void OnCollected()
    {
        _light.Collected -= OnCollected;

        foreach (var wall in _walls)
            wall.SetActive(false);

        gameObject.SetActive(false);
    }
}

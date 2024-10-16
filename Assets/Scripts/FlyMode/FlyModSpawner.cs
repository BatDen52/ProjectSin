using System.Collections;
using UnityEngine;

public class FlyModSpawner : MonoBehaviour
{
    //[SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private LightBonus _bonusPrefab;
    [SerializeField] private float _bonusChance;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _delay;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    public static FlyModSpawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        _coroutine = StartCoroutine(Spawning());
    }

    public void StopSpawning()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            yield return _wait;

            if (Random.Range(0, 100 + 1) <= _bonusChance)
                Instantiate(_bonusPrefab, _points[Random.Range(0, _points.Length)]);
            //else 
            //    Instantiate(_asteroidPrefab, _points[Random.Range(0, _points.Length)]);
        }
    }
}

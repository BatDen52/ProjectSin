using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GranySpawner : MonoBehaviour
{
    [SerializeField] private FlyGrany[] _prefabs;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxCount = 10;
    [SerializeField] private float _minSpawnDelay = 1;
    [SerializeField] private float _maxSpawnDelay = 2;
    [SerializeField] private bool _spawnOnStart = true;

    private Coroutine _coroutine;
    private List<FlyGrany> _granyes = new();

    private void Start()
    {
        if (_spawnOnStart == true)
            StartSpawn();
    }

    //private void OnDestroy()
    //{
    //    foreach (Grany letter in _letters)
    //    {
    //        letter.Falled -= OnFalled;
    //        Destroy(letter);
    //    }

    //    _letters.Clear();
    //}

    public void StartSpawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawning());
    }

    public void PushAll(Vector3 position, float pushForce)
    {
        StopSpawn();

        foreach (FlyGrany grany in _granyes)
        {
            grany.Push(position, pushForce);
        }
    }

    public void StopSpawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawning()
    {
        while (_maxCount <= 0 || _granyes.Count < _maxCount)
        {
            ResetGrany(GetGrany());

            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }

    private FlyGrany GetGrany()
    {
        FlyGrany grany;//= _letters.FirstOrDefault(i => i.gameObject.activeInHierarchy == false);

        //if (letter == null)
        {
            grany = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);
            _granyes.Add(grany);
        }

        return grany;
    }

    private void ResetGrany(FlyGrany grany)
    {
        int pointIndex = Random.Range(0, _points.Length);

        grany.transform.SetPositionAndRotation(_points[pointIndex].position, Quaternion.identity);

        //letter.Falled += OnFalled;
        //letter.Rigidbody.velocity = Vector3.zero;

        grany.Init(_target);

        grany.gameObject.SetActive(true);
    }

    //private void OnFalled(FlyGrany letter)
    //{
    //    //letter.Falled -= OnFalled;
    //    letter.gameObject.SetActive(false);
    //}
}

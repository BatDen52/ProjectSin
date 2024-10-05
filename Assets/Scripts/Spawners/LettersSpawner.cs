using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LettersSpawner : MonoBehaviour
{
    [SerializeField] private FalledLetter[] _prefabs;
    [SerializeField] private Canvas _container;
    [SerializeField] private Transform _leftBrder;
    [SerializeField] private Transform _rightBrder;
    [SerializeField] private float _minSpawnDelay = 1;
    [SerializeField] private float _maxSpawnDelay = 3;
    [SerializeField] private bool _spawnOnStart = true;

    private Coroutine _coroutine;
    private List<FalledLetter> _letters = new();

    private void Start()
    {
        if (_spawnOnStart == true)
            StartSpawn();
    }

    private void OnDestroy()
    {
        foreach (FalledLetter letter in _letters)
        {
            letter.Falled -= OnFalled;
            Destroy(letter);
        }

        _letters.Clear();
    }

    public void StartSpawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawning());
    }

    public void StopSpawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            ResetLetter(GetLetter());

            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }

    private FalledLetter GetLetter()
    {
        FalledLetter letter = _letters.FirstOrDefault(i => i.gameObject.activeInHierarchy == false);

        if (letter == null)
        {
            letter = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], _container.transform);
            _letters.Add(letter);
        }

        return letter;
    }

    private void ResetLetter(FalledLetter letter)
    {
        Vector3 position = transform.position;
        position.x = Random.Range(_leftBrder.position.x, _rightBrder.position.x);

        letter.transform.SetPositionAndRotation(position, Quaternion.identity);

        letter.Falled += OnFalled;
        letter.Rigidbody.velocity = Vector3.zero;

        letter.gameObject.SetActive(true);
    }

    private void OnFalled(FalledLetter letter)
    {
        letter.Falled -= OnFalled;
        letter.gameObject.SetActive(false);
    }
}

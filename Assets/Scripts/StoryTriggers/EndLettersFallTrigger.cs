using UnityEngine;

public class EndLettersFallTrigger : MonoBehaviour
{
    [SerializeField] private LettersSpawner _spawner;
    [SerializeField] private GameObject _lettersPlatform;
    [SerializeField] private GameObject _grany1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spawner.StopSpawn();
        _lettersPlatform.SetActive(true);
        _grany1.SetActive(false);
    }
}

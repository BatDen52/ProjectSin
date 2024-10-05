using UnityEngine;

public class LettersFallTrigger : MonoBehaviour
{
    [SerializeField] private LettersSpawner _spawner;
    [SerializeField] private EndLettersFallTrigger _endFallTrigger;
    [SerializeField] private GameObject _grany1;
    [SerializeField] private GameObject _wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        _spawner.StartSpawn();
        _endFallTrigger.gameObject.SetActive(true);
        gameObject.SetActive(false);
        _grany1.SetActive(false);
        _wall.gameObject.SetActive(true);
    }
}

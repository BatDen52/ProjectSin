using UnityEngine;

public class LettersFallTrigger : MonoBehaviour
{
    [SerializeField] private LettersSpawner _spawner;
    [SerializeField] private EndLettersFallTrigger _endFallTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        _spawner.StartSpawn();
        _endFallTrigger.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

using UnityEngine;

public class LettersFallTrigger : MonoBehaviour
{
    [SerializeField] private LettersSpawner _spawner;
    [SerializeField] private EndLettersFallTrigger _endFallTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spawner.StartSpawn();
        _endFallTrigger.gameObject.SetActive(true);
    }
}

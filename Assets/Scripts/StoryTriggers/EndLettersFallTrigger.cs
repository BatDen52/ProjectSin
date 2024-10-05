using UnityEngine;

public class EndLettersFallTrigger : MonoBehaviour
{
    [SerializeField] private LettersSpawner _spawner;
    [SerializeField] private GameObject _lettersPlatform;
    [SerializeField] private GameObject _grany1;
    [SerializeField] private LightRunAway1Trigger _lightRunAway1Trigget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        _spawner.StopSpawn();
        _lettersPlatform.SetActive(true);
        _grany1.SetActive(false);
        _lightRunAway1Trigget.gameObject.SetActive(true);
    }
}

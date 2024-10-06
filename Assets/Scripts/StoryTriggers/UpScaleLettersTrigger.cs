using UnityEngine;

public class UpScaleLettersTrigger : MonoBehaviour
{
    [SerializeField] private float _addedValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        LettersSpawner.Instance.UpCoefficient(_addedValue);
        enabled = false;
    }
}

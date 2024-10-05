using UnityEngine;

public class HidePicturesTrigger : MonoBehaviour
{
    [SerializeField] private LithingZone[] _pictures;
    [SerializeField] private LettersFallTrigger _fallTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        foreach (var picture in _pictures)
            picture.gameObject.SetActive(false);

        _fallTrigger.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

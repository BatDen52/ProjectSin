using TMPro;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Grany1Trigger : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private LithingZone _picture1;
    [SerializeField] private LettersFallTrigger _fallTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _) == false)
            return;

        _text.gameObject.SetActive (true);
        _picture1.gameObject.SetActive (false);
        _fallTrigger.gameObject.SetActive (true);
    }
}

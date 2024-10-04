using DG.Tweening;
using UnityEngine;

public class SoulsLight : Interactable
{
    [SerializeField] private float _hideSpeed;

    public override void Interact()
    {
        GetComponent<Collider2D>().enabled = false;

        transform.DOScale(Vector2.zero, _hideSpeed)
            .OnComplete(() => gameObject.SetActive(false));
    }

}

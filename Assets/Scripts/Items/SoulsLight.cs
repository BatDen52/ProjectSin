using DG.Tweening;
using System;
using UnityEngine;

public class SoulsLight : Interactable
{
    [SerializeField] private float _hideSpeed;

    public event Action Collected;

    public override void Interact()
    {
        GetComponent<Collider2D>().enabled = false;

        transform.DOScale(Vector2.zero, _hideSpeed)
            .OnComplete(() => gameObject.SetActive(false));

        Collected?.Invoke();
    }
}

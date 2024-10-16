using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SoulsLight : Interactable
{
    [SerializeField] private Light2D _light;
    [SerializeField] private float _hideTime = 1;
    [SerializeField] private float _hideSpeed = 1;

    public event Action Collected;

    [field: SerializeField] public float InnetAdded { get; private set; } = 1.2f;
    [field: SerializeField] public float OuterAdded { get; private set; } = 3.5f;


    public override void Interact()
    {
        GetComponent<Collider2D>().enabled = false;

        transform.DOScale(Vector2.zero, _hideSpeed)
            .OnComplete(() => gameObject.SetActive(false));
        
        StartCoroutine(Hide(_hideTime));

        Collected?.Invoke();
    }

    private IEnumerator Hide(float showTime)
    {
        float startOuter = _light.pointLightOuterRadius;
        float startInner = _light.pointLightInnerRadius;
        float time = 0;

        while (_light.pointLightOuterRadius != 0 || _light.pointLightInnerRadius != 0)
        {
            time += Time.deltaTime;
            _light.pointLightOuterRadius = Mathf.Lerp(startOuter, 0, time / showTime);
            _light.pointLightInnerRadius = Mathf.Lerp(startInner, 0, time / showTime);

            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private float _showValueInner;
    [SerializeField] private float _showValueOuter;
    [SerializeField] private float _hideValueInner;
    [SerializeField] private float _hideValueOuter;
    [SerializeField] private float _showTime;
    [SerializeField] private float _hideTime;

    private Coroutine _coroutine;

    public bool IsOn { get; private set; }

    public void StartShow()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Showing());
    }

    public void StartHide()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Hideing());
    }

    private IEnumerator Showing()
    {
        float startOuter = _light.pointLightOuterRadius;
        float startInner = _light.pointLightInnerRadius;
        float time = 0;

        IsOn = true;

        while (_light.pointLightOuterRadius != _showValueOuter || _light.pointLightInnerRadius != _showValueInner)
        {
            time += Time.deltaTime;
            _light.pointLightOuterRadius = Mathf.Lerp(startOuter, _showValueOuter, time / _showTime);
            _light.pointLightInnerRadius = Mathf.Lerp(startInner, _showValueInner, time / _showTime);

            yield return null;
        }
    }

    private IEnumerator Hideing()
    {
        float startOuter = _light.pointLightOuterRadius;
        float startInner = _light.pointLightInnerRadius;
        float time = 0;

        IsOn = false;

        while (_light.pointLightOuterRadius != _hideValueOuter || _light.pointLightInnerRadius != _hideValueInner)
        {
            time += Time.deltaTime;

            _light.pointLightOuterRadius = Mathf.Lerp(startOuter, _hideValueOuter, time / _hideTime);
            _light.pointLightInnerRadius = Mathf.Lerp(startInner, _hideValueInner, time / _hideTime);

            yield return null;
        }
    }
}

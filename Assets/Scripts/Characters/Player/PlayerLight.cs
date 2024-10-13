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

    [SerializeField] private float _maxValueInner;
    [SerializeField] private float _maxValueOuter;

    [SerializeField] private float _showTime;
    [SerializeField] private float _hideTime;

    private Coroutine _coroutine;
    private float _targetValueInner;
    private float _targetValueOuter;

    public bool IsOn { get; private set; }
    public float Intensity => _light.intensity;

    public float TargetValueInner
    {
        get => _targetValueInner;
        set => _targetValueInner = Mathf.Clamp(value, 0, _maxValueInner);
    }
    public float TargetValueOuter
    {
        get => _targetValueOuter;
        set => _targetValueOuter = Mathf.Clamp(value, 0, _maxValueOuter);
    }

    public void StartShow(float showTime = -1, float targetValueInner = -1, float targetValueOuter = -1)
    {
        if (showTime == -1)
            showTime = _showTime;

        if (targetValueInner == -1)
            targetValueInner = _showValueInner;

        if (targetValueOuter == -1)
            targetValueOuter = _showValueOuter;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        IsOn = true;

        TargetValueInner += targetValueInner;
        TargetValueOuter += targetValueOuter;

        _coroutine = StartCoroutine(ChangeValue(showTime));
    }

    public void StartHide(float hideTime = -1, float targetValueInner = -1, float targetValueOuter = -1)
    {
        if (hideTime == -1)
            hideTime = _hideTime;

        if (targetValueInner == -1)
            targetValueInner = _hideValueInner;

        if (targetValueOuter == -1)
            targetValueOuter = _hideValueOuter;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        IsOn = false;

        TargetValueInner -= targetValueInner;
        TargetValueOuter -= targetValueOuter;

        _coroutine = StartCoroutine(ChangeValue(hideTime));
    }

    public void SetIntensity(float intensity)
    {
        _light.intensity = intensity;
    }

    public void AddForce(float innetAdded, float outerAdded)
    {
        StartShow(0.1f, innetAdded, outerAdded);
    }

    private IEnumerator ChangeValue(float showTime)
    {
        float startOuter = _light.pointLightOuterRadius;
        float startInner = _light.pointLightInnerRadius;
        float time = 0;

        while (_light.pointLightOuterRadius != TargetValueOuter || _light.pointLightInnerRadius != TargetValueInner)
        {
            time += Time.deltaTime;
            _light.pointLightOuterRadius = Mathf.Lerp(startOuter, TargetValueOuter, time / showTime);
            _light.pointLightInnerRadius = Mathf.Lerp(startInner, TargetValueInner, time / showTime);

            yield return null;
        }
    }
}

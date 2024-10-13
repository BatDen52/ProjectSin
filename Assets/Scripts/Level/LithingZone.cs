using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LithingZone : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private float _showIntensity;
    [SerializeField] private float _hideIntensity;
    [SerializeField] private float _showTime;
    [SerializeField] private float _hideTime;
    [SerializeField] private float _innetAdded;
    [SerializeField] private float _outerAdded;

    private Coroutine _coroutine;
    private bool _isUsed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerLight playerLight) && playerLight.IsOn == true)
        {
            StartShow();

            if (_isUsed == false)
            {
                _isUsed = true;
                playerLight.AddForce(_innetAdded, _outerAdded);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerLight playerLight))
            StartHide();
    }

    public void StartShow()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeIntensity(_showIntensity, _showTime));
    }

    public void StartHide()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeIntensity(_hideIntensity, _hideTime));
    }

    private IEnumerator ChangeIntensity(float targetValue, float targetTime)
    {
        float startIntensity = _light.intensity;
        float time = 0;

        while (_light.intensity != targetValue)
        {
            time += Time.deltaTime;
            _light.intensity = Mathf.Lerp(startIntensity, targetValue, time / targetTime);

            yield return null;
        }
    }
}

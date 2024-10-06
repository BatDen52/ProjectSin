using System.Collections;
using UnityEngine;

public class AutoPilotTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _black;
    [SerializeField] private SpriteRenderer _white;
    [SerializeField] private SpriteRenderer _unlitWhite;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _endAlpha = 255;
    [SerializeField] private float _time = 5;
    [SerializeField] private float _endCameraSize = 100;
    [SerializeField] private float _endCameraOffsetY = -29;

    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Pushing pushing) == false)
            return;

        pushing.AcivateAutoPilot();
        StartTimer();
    }

    private void StartTimer()
    {
        _coroutine = StartCoroutine(ChangingColor());
    }

    private IEnumerator ChangingColor()
    {
        Color blackColor = _black.color;
        Color whiteColor = _white.color;

        float currentTime = 0;

        while (currentTime < _time)
        {
            currentTime += Time.deltaTime;

            blackColor.a = whiteColor.a = Mathf.Lerp(0, _endAlpha, currentTime / _time);
            _black.color = blackColor;
            _white.color = whiteColor;
            yield return null;
        }

        currentTime = 0;
        Color unlitWhiteColor = _white.color;
        float startCameraSize = _camera.orthographicSize;
        float startCameraOffsetY = CameraFollower.Instance.Offset.y;

        while (currentTime < _time)
        {
            currentTime += Time.deltaTime;

            unlitWhiteColor.a = Mathf.Lerp(0, _endAlpha, currentTime / _time);
            _unlitWhite.color = unlitWhiteColor;
            _camera.orthographicSize = Mathf.Lerp(startCameraSize, _endCameraSize, currentTime / _time);
            CameraFollower.Instance.SetOffsetY(Mathf.Lerp(startCameraOffsetY, _endCameraOffsetY, currentTime / _time));

            yield return null;
        }
    }
}

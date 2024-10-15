using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Net;
using UnityEngine;

public class LightRunAway1Trigger : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private SpriteRenderer _plauerView;
    [SerializeField] private Material _unlitMaterial;
    [SerializeField] private PlayerLight _playerLight;
    [SerializeField] private SoulsLight _soulsLightPrefab;
    [SerializeField] private Transform _soulsLightEndPoint;
    [SerializeField] private float _speedLight;
    [SerializeField] private RectTransform _uiGrany;
    [SerializeField] private Vector3 _granyEndPosition;
    [SerializeField] private GameObject _platform1Container;
    [SerializeField] private GameObject[] _walls;
    [SerializeField] private LightRunAway2Trigger _lightRunAway2Trigget;
    [SerializeField] private Collider2D _newCameraBorder;
    [SerializeField] private CinemachineConfiner2D _cameraConfiner;
    [SerializeField] private CinemachineVirtualCamera _camera;

    private Vector3 _granyStartPosition;
    private SoulsLight _light;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _) == false)
            return;

        foreach (var wall in _walls)
            wall.SetActive(true);

        _granyStartPosition = _uiGrany.position;
        GetComponent<Collider2D>().enabled = false;
        _uiGrany.DOAnchorPos(_granyEndPosition, 1).OnComplete(() => StartCoroutine(RunAway()));
    }

    private IEnumerator RunAway()
    {
        _playerLight.StartHide();
        _light = Instantiate(_soulsLightPrefab, _playerLight.transform.position, Quaternion.identity);
        _light.Collected += OnCollected;

        _light.GetComponent<Collider2D>().enabled = false;

        _uiGrany.DOAnchorPos(_granyStartPosition, 1)
            .OnComplete(() => _platform1Container.SetActive(true));

        _animator.SetBlack();

        _plauerView.material = _unlitMaterial;

        _camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;
        _cameraConfiner.m_MaxWindowSize = 10f;

        _cameraConfiner.m_BoundingShape2D = _newCameraBorder;

        yield return StartCoroutine(Runing(_light.transform, _soulsLightEndPoint.position, _speedLight));

        _light.GetComponent<Collider2D>().enabled = true;
    }

    private void OnCollected()
    {
        _light.Collected -= OnCollected;
        _platform1Container.SetActive(false);
        _lightRunAway2Trigget.gameObject.SetActive(true);

        foreach (var wall in _walls)
            wall.SetActive(false);
    }

    private IEnumerator Runing(Transform light, Vector3 endPosition, float speed)
    {
        while (light.position != endPosition)
        {
            light.position = Vector3.MoveTowards(light.position, endPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

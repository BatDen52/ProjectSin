using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Grany1Trigger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _grany;
    [SerializeField] private float _maxZoomDistance = 16;
    [SerializeField] private float _minZoomDistance = 6;
    [SerializeField] private GameObject _text;
    [SerializeField] private LithingZone[] _oldPictures;
    [SerializeField] private LithingZone[] _newPictures;
    [SerializeField] private HidePicturesTrigger _hidePicturesTrigger;
    [SerializeField] private Collider2D _newCameraBorder;
    [SerializeField] private CinemachineConfiner2D _cameraConfiner;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float _minCameraSize = 3;

    private float _cameraSize;

    private void Awake()
    {
        _cameraSize = _camera.m_Lens.OrthographicSize;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _) == false)
            return;

        _text.gameObject.SetActive(true);
        _hidePicturesTrigger.gameObject.SetActive(true);

        foreach (var picture in _oldPictures)
            picture.gameObject.SetActive(false);

        foreach (var picture in _newPictures)
            picture.gameObject.SetActive(true);

        _cameraConfiner.m_BoundingShape2D = _newCameraBorder;
    }

    private void Update()
    {
        float sqrDistance = (_grany.transform.position - _player.transform.position).sqrMagnitude;

        if (sqrDistance > _maxZoomDistance * _maxZoomDistance || sqrDistance < _minZoomDistance * _minZoomDistance)
            return;

        float distanceCoefficient = (sqrDistance - _minZoomDistance * _minZoomDistance) /
            (_maxZoomDistance * _maxZoomDistance - _minZoomDistance * _minZoomDistance);

        _camera.m_Lens.OrthographicSize = Mathf.Lerp(_minCameraSize, _cameraSize, distanceCoefficient);
    }
}

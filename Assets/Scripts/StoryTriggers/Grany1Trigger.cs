using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Grany1Trigger : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private LithingZone[] _oldPictures;
    [SerializeField] private LithingZone[] _newPictures;
    [SerializeField] private HidePicturesTrigger _hidePicturesTrigger;
    [SerializeField] private Collider2D _newCameraBorder;
    [SerializeField] private CinemachineConfiner2D _cameraConfiner;

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
}

using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LightRunAway1Trigger : MonoBehaviour
{
    [SerializeField] private PlayerLight _playerLight;
    [SerializeField] private SoulsLight _soulsLightPrefab;
    [SerializeField] private Transform _soulsLightEndPoint;
    [SerializeField] private float _speedLight;
    [SerializeField] private RectTransform _uiGrany;
    [SerializeField] private Vector3 _granyEndPosition;
    [SerializeField] private GameObject _platform1Container;

    private Vector3 _granyStartPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _granyStartPosition = _uiGrany.position;
        GetComponent<Collider2D>().enabled = false;
        _uiGrany.DOAnchorPos(_granyEndPosition, 1).OnComplete(() => StartCoroutine(RunAway()));
    }

    private IEnumerator RunAway()
    {
        _playerLight.StartHide();
        SoulsLight light = Instantiate(_soulsLightPrefab, _playerLight.transform.position, Quaternion.identity);
        light.GetComponent<Collider2D>().enabled = false;

        yield return StartCoroutine(Runing(light.transform, _soulsLightEndPoint.position, _speedLight));
        Debug.Log("333333333333");

        light.GetComponent<Collider2D>().enabled = true;

        Debug.Log("4444444");
        _uiGrany.DOAnchorPos(_granyStartPosition, 1)
            .OnComplete(() => _platform1Container.SetActive(true));
    }

    private IEnumerator Runing(Transform light, Vector3 endPosition, float speed)
    {
        Debug.Log("111111111111");
        while (light.position != endPosition)
        {
            Debug.Log("2222222222222");
            light.position = Vector3.MoveTowards(light.position, endPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

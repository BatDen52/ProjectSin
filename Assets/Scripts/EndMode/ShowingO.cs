using System.Collections;
using UnityEngine;

public class ShowingO : MonoBehaviour
{
    [SerializeField] private float _showDelay = 10;
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private Pushing _pushing;

    private Coroutine _coroutine;

    private void Awake()
    {
        _coroutine = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        _pushing.enabled = true;

        yield return new WaitForSeconds(_showDelay);

        if (Input.GetKey(KeyCode.E) == false)
            _tutorial.SetActive(true);

        CameraFollower.Instance.enabled = true;
        CameraFollower.Instance.Follow();

        while (Input.GetKey(KeyCode.E) == false)
            yield return null;

        yield return new WaitForSeconds(0.5f);
        _tutorial.SetActive(false);
    }
}

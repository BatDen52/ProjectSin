using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GranyAttackTrigger : MonoBehaviour
{
    [SerializeField] private GranySpawner _granySpawner;
    [SerializeField] private PlayerLight _playerLight;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Canvas _interactableCanvas;

    [Header("Timer")]
    //[SerializeField] private int _step = 1;
    [SerializeField] private int _totalTime = 25;

    [Header("Push")]
    [SerializeField] private int _clickECount = 15;
    [SerializeField] private float _pushForce = 15;

    private float _currentTime = 0;
    private int _currentClicks = 0;
    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_coroutine != null && collision.TryGetComponent<Player>(out _) == false)
            return;

        _granySpawner.StartSpawn();

        StartTimer();
    }

    private void StartTimer()
    {
        _coroutine = StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        _playerLight.StartHide(_totalTime);

        while (_currentTime < _totalTime)
        {
            _currentTime += Time.deltaTime;
            yield return null;
        }

        _interactableCanvas.gameObject.SetActive(true);

        while (_currentClicks < _clickECount)
        {
            if (Input.GetKeyDown(KeyCode.E))
                _currentClicks++;

            yield return null;
        }

        _interactableCanvas.gameObject.SetActive(false);

        _granySpawner.PushAll(_playerLight.transform.position, _pushForce);

        _playerLight.StartShow();

        yield return new WaitForSeconds(1.5f);

        CameraFollower.Instance.StopFollow();
        _playerAnimator.SetFly();
        _playerAnimator.GetComponent<Rigidbody2D>().gravityScale = 0;
        _playerAnimator.transform.DOMove(_playerAnimator.transform.position + Vector3.up * 20, 2);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("FlyMode");
    }
}

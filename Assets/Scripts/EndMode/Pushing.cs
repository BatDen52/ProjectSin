using UnityEngine;

public class Pushing : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private Animator _animator;

    private bool _isAutoPilot;

    private void Update()
    {
        if (_isAutoPilot || Input.GetKey(KeyCode.O))
        {
            _animator.SetBool("Push", true);
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("Push", false);
        }
    }

    public void AcivateAutoPilot()
    {
        _isAutoPilot = true;
    }
}

using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetSpeedX(float speedX)
    {
        _animator.SetFloat(ConstantsData.AnimatorParameters.SpeedX, Mathf.Abs(speedX));
    }

    public void SetFly()
    {
        _animator.SetTrigger(ConstantsData.AnimatorParameters.IsFly);
    }

    public void SetBlack()
    {
        _animator.SetBool(ConstantsData.AnimatorParameters.IsBlack, true);
    }

    public void SetUnblack()
    {
        _animator.SetBool(ConstantsData.AnimatorParameters.IsBlack, false);
    }

    public void SetAttackTrigger()
    {
        _animator.SetTrigger(ConstantsData.AnimatorParameters.IsAttack);
    }

    public void SetHitTrigger()
    {
        _animator.SetTrigger(ConstantsData.AnimatorParameters.IsHit);
    }
}

using UnityEngine;

public static class ConstantsData
{
    public static class AnimatorParameters
    {
        public static readonly int SpeedX = Animator.StringToHash(nameof(SpeedX));
        public static readonly int IsFly = Animator.StringToHash(nameof(IsFly));
        public static readonly int IsBlack = Animator.StringToHash(nameof(IsBlack));
        public static readonly int IsOn = Animator.StringToHash(nameof(IsOn));
        public static readonly int IsOff = Animator.StringToHash(nameof(IsOff));
        public static readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
        public static readonly int IsHit = Animator.StringToHash(nameof(IsHit));
    }

    public static class Tags
    {
        public const string GROUND_TAG = "Ground";
    }

    public static class InputData
    {
        public const string HORIZONTAL_AXIS = "Horizontal";
    }

    public static class SavaData
    {
        public const float DefaultMusicVolume = 1;
        public const float DefaultSoundVolume = 1;
    }
}

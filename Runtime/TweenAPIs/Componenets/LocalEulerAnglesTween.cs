namespace SAS.TweenManagment
{
    sealed class LocalEulerAnglesTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.LocalEulerAngles(_transform, m_from, m_To, m_ParamConfig.value);
        }
    }
}

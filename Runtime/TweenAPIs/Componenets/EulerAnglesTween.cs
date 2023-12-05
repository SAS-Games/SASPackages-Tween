namespace SAS.TweenManagment
{
    sealed class EulerAnglesTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.EulerAngles(_transform, m_from, m_To, m_ParamConfig.value);
        }
    }
}

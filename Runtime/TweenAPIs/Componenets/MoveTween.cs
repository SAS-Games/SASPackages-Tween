namespace SAS.TweenManagment
{
    sealed class MoveTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.Move(_transform, m_from, m_To, m_ParamConfig.value);
        }
    }
}

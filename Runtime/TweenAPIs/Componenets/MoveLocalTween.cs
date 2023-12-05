namespace SAS.TweenManagment
{
    sealed class MoveLocalTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.MoveLocal(_transform, m_from, m_To, m_ParamConfig.value);
        }
    }
}

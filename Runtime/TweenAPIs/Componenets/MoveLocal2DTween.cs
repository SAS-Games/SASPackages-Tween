namespace SAS.TweenManagment
{
    sealed class MoveLocal2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.MoveLocal(_transform, m_from, m_To, m_ParamConfig.value);
        }
    }
}

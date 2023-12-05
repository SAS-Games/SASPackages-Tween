namespace SAS.TweenManagment
{
    sealed class Scale2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.Scale(_transform, m_from, m_To, m_ParamConfig.value);
        }
    }
}

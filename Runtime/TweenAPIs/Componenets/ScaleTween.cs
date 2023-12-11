namespace SAS.TweenManagment
{
    sealed class ScaleTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Scale(_transform, m_from, m_To, m_ParamConfig.value);
        }

        protected override void Reset()
        {
            _transform.SetLocalScale(m_from);
        }
    }
}

namespace SAS.TweenManagement
{
    sealed class Scale2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Scale(_transform, m_from, m_To, ref m_ParamConfig);
        }

        protected override void Reset()
        {
            _transform.SetLocalScale(m_from);
        }
    }
}

namespace SAS.TweenManagement
{
    sealed class MoveTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Move(_transform, m_from, m_To, ref m_ParamConfig);
        }

        protected override void Reset()
        {
            _transform.SetPosition(m_from);
        }
    }
}

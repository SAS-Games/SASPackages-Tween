namespace SAS.TweenManagment
{
    sealed class Move2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.Move(_transform, m_from, m_To, m_ParamConfig.value);
        }

        protected override void Reset()
        {
            _transform.SetPosition(m_from);
        }
    }
}

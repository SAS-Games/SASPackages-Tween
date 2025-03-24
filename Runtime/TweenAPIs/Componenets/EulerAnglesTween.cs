namespace SAS.TweenManagement
{
    sealed class EulerAnglesTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.EulerAngles(_transform, m_from, m_To, ref m_ParamConfig);
        }

        protected override void Reset()
        {
            _transform.SetEulerAngles(m_from);
        }
    }
}

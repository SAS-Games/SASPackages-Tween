namespace SAS.TweenManagement
{
    sealed class LocalEulerAnglesTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.LocalEulerAngles(_transform, m_from, m_To, m_ParamConfig.value);
        }

        protected override void Reset()
        {
            _transform.SetLocalEulerAngles(m_from);
        }
    }
}

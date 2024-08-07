namespace SAS.TweenManagement
{
    sealed class MoveLocal2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.MoveLocal(_transform, m_from, m_To, m_ParamConfig.value);
        }

        protected override void Reset()
        {
            _transform.SetLocalPosition(m_from);
        }
    }
}

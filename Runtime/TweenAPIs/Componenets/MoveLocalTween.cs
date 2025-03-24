namespace SAS.TweenManagement
{
    sealed class MoveLocalTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.MoveLocal(_transform, m_from, m_To, ref m_ParamConfig);
        }

        protected override void Reset()
        {
            _transform.SetLocalPosition(m_from);
        }
    }
}

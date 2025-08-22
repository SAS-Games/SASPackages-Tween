using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class Scale2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Scale(_transform, _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }

        protected override Vector2 GetCurrentValue() => _transform.localScale;

        protected override void Reset()
        {
            _transform.SetLocalScale(_resolvedFrom);
        }
    }
}

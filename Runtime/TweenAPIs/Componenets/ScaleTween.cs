using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class ScaleTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Scale(_transform, _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.localScale;

        protected override void Reset()
        {
            _transform?.SetLocalScale(_resolvedFrom);
        }
    }
}

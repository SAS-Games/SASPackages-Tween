using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class MoveLocal2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.MoveLocal(_transform, _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }

        protected override Vector2 GetCurrentValue() => _transform.localPosition;

        protected override void Reset()
        {
            _transform?.SetLocalPosition(_resolvedTo);
        }
    }
}

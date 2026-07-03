using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class ScaleTween : V3TweenMonoBase
    {
        protected override TweenBase CreateTween()
        {
            return Tween.Scale(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.localScale;

        protected override void Reset()
        {
            _transform?.SetLocalScale(_resolvedFrom);
        }
    }
}
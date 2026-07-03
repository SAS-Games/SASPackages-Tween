using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class Scale2DTween : V2TweenMonoBase
    {
        protected override TweenBase CreateTween()
        {
            return Tween.Scale(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector2 GetCurrentValue() => _transform.localScale;

        protected override void Reset()
        {
            _transform?.SetLocalScale(_resolvedFrom);
        }
    }
}

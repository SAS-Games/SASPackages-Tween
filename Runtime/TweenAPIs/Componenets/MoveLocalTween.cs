using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class MoveLocalTween : V3TweenMonoBase
    {
        protected override TweenBase CreateTween()
        {
            return Tween.MoveLocal(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.localPosition;
        protected override void Reset()
        {
            _transform?.SetLocalPosition(_resolvedFrom);
        }
    }
}

using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class EulerAnglesTween : V3TweenMonoBase
    {
        protected override TweenBase CreateTween()
        {
            return Tween.EulerAngles(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.eulerAngles;

        protected override void Reset()
        {
            _transform?.SetEulerAngles(_resolvedFrom);
        }
    }
}

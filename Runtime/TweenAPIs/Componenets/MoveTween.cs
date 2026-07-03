using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class MoveTween : V3TweenMonoBase
    {
        protected override TweenBase CreateTween()
        {
            return Tween.Move(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.position;


        protected override void Reset()
        {
            _transform?.SetPosition(_resolvedFrom);
        }
    }
}
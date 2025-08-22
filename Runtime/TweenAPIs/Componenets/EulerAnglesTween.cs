using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class EulerAnglesTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.EulerAngles(_transform, _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.eulerAngles;

        protected override void Reset()
        {
            _transform?.SetEulerAngles(_resolvedFrom);
        }
    }
}

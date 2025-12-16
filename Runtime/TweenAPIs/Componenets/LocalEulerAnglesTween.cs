using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class LocalEulerAnglesTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.LocalEulerAngles(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue()=> _transform.localEulerAngles;

        protected override void Reset()
        {
            _transform?.SetLocalEulerAngles(_resolvedFrom);
        }
    }
}

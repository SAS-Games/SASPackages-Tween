using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class MoveLocalTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.MoveLocal(_transform, _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }
        
        protected override Vector3 GetCurrentValue()=> _transform.localPosition;

        protected override void Reset()
        {
            _transform?.SetLocalPosition(_resolvedFrom);
        }
    }
}

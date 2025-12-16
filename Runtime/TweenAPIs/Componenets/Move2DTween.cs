using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class Move2DTween : V2TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Move(_transform, _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override Vector2 GetCurrentValue() => transform.position;


        protected override void Reset()
        {
            _transform?.SetPosition(_resolvedFrom);
        }
    }
}

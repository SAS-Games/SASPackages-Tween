using UnityEngine;

namespace SAS.TweenManagement
{
    sealed class MoveTween : V3TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Move(_transform, _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }

        protected override Vector3 GetCurrentValue() => _transform.position;


        protected override void Reset()
        {
            _transform.SetPosition(_resolvedFrom);
        }
    }
}

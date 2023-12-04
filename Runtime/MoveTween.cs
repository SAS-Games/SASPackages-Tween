using UnityEngine;

namespace SAS.TweenManagment
{
    sealed class MoveTween : TweenMonoBase
    {
        [SerializeField] Vector3 m_TargetPosition = Vector3.one;

        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.Move(_transform, m_TargetPosition, m_ParamConfig.value);
        }
    }
}

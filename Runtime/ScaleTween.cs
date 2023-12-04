using UnityEngine;

namespace SAS.TweenManagment
{
    sealed class ScaleTween : TweenMonoBase
    {
        [SerializeField] Vector3 m_TargetScale = Vector3.one;

        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.Scale(_transform, m_TargetScale, m_ParamConfig.value);
        }
    }
}

using UnityEngine;

namespace SAS.TweenManagment
{
    sealed class CanvasGroupAlphaTween : TweenMonoBase
    {
        [SerializeField] float m_Alpha = 1;

        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            Tween.Alpha(_transform.GetComponent<CanvasGroup>(), m_Alpha, m_ParamConfig.value);
        }
    }
}



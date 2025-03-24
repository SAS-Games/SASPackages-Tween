using UnityEngine;

namespace SAS.TweenManagement
{
    [RequireComponent(typeof(CanvasGroup))]
    sealed class CanvasGroupAlphaTween : V1TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Alpha(_transform.GetComponent<CanvasGroup>(), m_from, m_To, ref m_ParamConfig);
        }

        protected override void Reset()
        {
            _transform.GetComponent<CanvasGroup>().SetAlpha(m_from);
        }
    }
}



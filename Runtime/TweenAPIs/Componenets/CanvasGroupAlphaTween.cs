using UnityEngine;

namespace SAS.TweenManagement
{
    [RequireComponent(typeof(CanvasGroup))]
    sealed class CanvasGroupAlphaTween : V1TweenMonoBase
    {
        public override void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            base.Play(ontweenCompleted);
            _tween = Tween.Alpha(_transform.GetComponent<CanvasGroup>(), _resolvedFrom, _resolvedTo, ref m_ParamConfig);
        }

        protected override float GetCurrentValue() => _transform.GetComponent<CanvasGroup>().alpha;
        protected override void Reset()
        {
            _transform.GetComponent<CanvasGroup>().SetAlpha(_resolvedFrom);
        }
    }
}



using UnityEngine;

namespace SAS.TweenManagement
{
    [RequireComponent(typeof(CanvasGroup))]
    sealed class CanvasGroupAlphaTween : V1TweenMonoBase
    {
        protected override TweenBase CreateTween()
        {
            return Tween.Alpha(_transform.GetComponent<CanvasGroup>(), _resolvedFrom, _resolvedTo, m_ParamConfig);
        }

        protected override float GetCurrentValue() => _transform.GetComponent<CanvasGroup>().alpha;
        protected override void Reset()
        {
            _transform?.GetComponent<CanvasGroup>()?.SetAlpha(_resolvedFrom);
        }
    }
}



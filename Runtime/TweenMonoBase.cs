using UnityEngine;
using UnityEngine.Events;

namespace SAS.TweenManagment
{
    internal class TweenMonoBase : MonoBehaviour, ITweenComponent
    {
        [SerializeField] private UnityEvent OnCompleteEvent;
        [SerializeField] protected ScriptableReadOnlyTweenConfig m_ParamConfig;
        [SerializeField] private bool m_PlayOnEnable = false;


        protected Transform _transform;
        protected ITween _tween;

        void OnEnable()
        {
            if (m_PlayOnEnable) Play();
        }

        public virtual void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            if (!_transform)
                _transform = transform;
            if (ontweenCompleted != null)
                m_ParamConfig.value.TweenCompleteCallback(ontweenCompleted);
        }

        public void Play()
        {
            Play(_ => OnCompleteEvent?.Invoke());
        }

        void OnDestroy()
        {
            _tween.Stop(false);
            _transform = null;
        }

    }
}
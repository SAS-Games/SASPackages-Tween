using System;
using UnityEngine;
using UnityEngine.Events;

namespace SAS.TweenManagement
{
    public abstract class TweenMonoBase : MonoBehaviour, ITweenComponent
    {
        [SerializeField] private bool m_PlayOnEnable = false;
        [SerializeField] protected TweenConfig m_ParamConfig;
        [SerializeField] UnityEvent m_OnTweenComplete;

        protected Transform _transform;
        protected TweenBase _tween;
        public TweenBase TweenInstance => _tween;
        private Action _onComplete;

        void OnEnable()
        {
            if (m_PlayOnEnable) Play();
        }

        public virtual void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            if (!_transform)
                _transform = transform;
            _tween.RemoveCallback(m_OnTweenComplete.Invoke);
            _tween.AddCallback(m_OnTweenComplete.Invoke);
            if (ontweenCompleted != null)
                _tween.AddCallback(ontweenCompleted);
        }

        public void Play()
        {
            Play(null);
        }

        protected abstract void Reset();

        protected void OnDisable()
        {
            Reset();
            _tween?.Stop(true);
        }

        void OnDestroy()
        {
            _tween?.Stop(true);
            _transform = null;
        }

        public ref TweenConfig UpdateAndGetRefToParamConfig()
        {
            return ref m_ParamConfig;
        }
    }
}
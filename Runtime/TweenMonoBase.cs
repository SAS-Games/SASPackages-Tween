using System;
using UnityEngine;
using UnityEngine.Events;

namespace SAS.TweenManagement
{
    public abstract class TweenMonoBase : MonoBehaviour, ITweenComponent
    {
        [SerializeField] private bool m_PlayOnEnable = false;
        [SerializeField] protected TweenConfig m_ParamConfig;
        [SerializeField] private UnityEvent m_OnTweenComplete;

        protected Transform _transform;
        protected TweenBase _tween;

        public TweenBase TweenInstance => _tween;

        private void OnEnable()
        {
            if (m_PlayOnEnable)
                Play();
        }

        public void Play()
        {
            Play(null);
        }

        public void Play(OnAnimationCompleteCallback onTweenCompleted)
        {
            if (!_transform)
                _transform = transform;

            PrepareTween();

            _tween?.Stop(true);
            _tween = CreateTween();

            if (_tween == null)
                throw new InvalidOperationException($"{GetType().Name} did not create a tween.");

            _tween.RemoveCallback(m_OnTweenComplete.Invoke);
            _tween.AddCallback(m_OnTweenComplete.Invoke);

            if (onTweenCompleted != null)
                _tween.AddCallback(onTweenCompleted);
        }

        protected abstract void PrepareTween();

        protected abstract TweenBase CreateTween();

        protected abstract void Reset();

        protected void OnDisable()
        {
            Reset();
            _tween?.Stop(true);
        }

        private void OnDestroy()
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
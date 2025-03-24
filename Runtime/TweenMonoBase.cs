using UnityEngine;

namespace SAS.TweenManagement
{
    internal abstract class TweenMonoBase : MonoBehaviour, ITweenComponent
    {
        [SerializeField] private bool m_PlayOnEnable = false;
        [SerializeField] protected TweenConfig m_ParamConfig;

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
                m_ParamConfig.TweenCompleteCallback(ontweenCompleted);
        }

        public void Play()
        {
            Play(null);
        }

        protected abstract void Reset();

        protected void OnDisable()
        {
            Reset();
            _tween?.Stop(false);
        }

        void OnDestroy()
        {
            _tween?.Stop(false);
            _transform = null;
        }
    }
}
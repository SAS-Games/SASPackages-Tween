using UnityEngine;

namespace SAS.TweenManagement
{
    public abstract class TweenMonoBase : MonoBehaviour, ITweenComponent
    {
        [SerializeField] private bool m_PlayOnEnable = false;
        [SerializeField] protected TweenConfig m_ParamConfig;

        protected Transform _transform;
        protected ITween _tween;
        public ITween TweenInstance => _tween;


        void OnEnable()
        {
            if (m_PlayOnEnable) Play();
        }

        public virtual void Play(OnAnimationCompleteCallback ontweenCompleted)
        {
            if (!_transform)
                _transform = transform;
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

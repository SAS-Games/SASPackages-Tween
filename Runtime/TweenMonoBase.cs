using UnityEngine;

namespace SAS.TweenManagment
{
    internal class TweenMonoBase : MonoBehaviour, ITweenComponent
    {
        [SerializeField] protected ScriptableReadOnlyTweenConfig m_ParamConfig;
        [SerializeField] private bool m_PlayOnEnable = false;

        protected Transform _transform;

        void OnEnable()
        {
            if (m_PlayOnEnable) Play();
        }

        public virtual void Play(OnAnimationCompleteCallback ontweenCompleted = default)
        {
            if (!_transform)
                _transform = transform;
            if (ontweenCompleted != null)
                m_ParamConfig.value.TweenCompleteCallback(ontweenCompleted);
        }
    }
}
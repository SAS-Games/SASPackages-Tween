using UnityEngine;
using UnityEngine.Events;

namespace SAS.TweenManagment
{
    [System.Serializable]
    public struct TweenConfig
    {
        [SerializeField] private bool m_IsTimeBased;
        [SerializeField] private float m_DurationOrSpeed;
        [SerializeField] private float m_Delay;
        [SerializeField] private int m_LoopCount;
        [SerializeField] private bool m_PingPong;
        [SerializeField] private EaseType m_Type;
        [SerializeField] private bool m_UseAnimationCurve;
        [SerializeField] private AnimationCurve m_AnimationCurve;

        public UnityEvent OnTweeningComplete;
        private CustomCurve mCustomCurve;
        public OnAnimationCompleteCallback OnTweenCompleteCallback { get; private set; }

        public CustomCurve CustomAnimationCurve
        {
            get
            {
                if (mCustomCurve == null)
                    mCustomCurve = Tween.GetCustomCurve(m_Type);
                return mCustomCurve;
            }
        }

        public float DurationOrSpeed { get => m_DurationOrSpeed; }
        public float Delay { get => m_Delay; }
        public int LoopCount { get => m_LoopCount == 0 ? 1 : m_LoopCount; }
        public bool PingPong { get => m_PingPong; }
        public EaseType EaseType { get => m_Type; }
        public bool UseAnimationCurve { get => m_UseAnimationCurve; }
        public AnimationCurve AnimationCurve { get => m_AnimationCurve; }
        public bool IsTimeBased { get => m_IsTimeBased; }
        public float Delta { get; set; }

        public TweenConfig Duration(float duration)
        {
            m_IsTimeBased = true;
            m_DurationOrSpeed = duration;
            return this;
        }

        public TweenConfig Speed(float duration)
        {
            if (!m_IsTimeBased)
            {
                m_DurationOrSpeed = duration;
            }
            else Debug.LogWarning("Tween Duration has already been set. Setting the speed will not have any effect");

            return this;
        }

        public TweenConfig WithDelay(float delay)
        {
            m_Delay = delay;
            return this;
        }

        public TweenConfig WithLoop(int loopConut)
        {
            m_LoopCount = loopConut;
            return this;
        }

        public TweenConfig WithPingPong()
        {
            m_PingPong = true;
            return this;
        }

        public TweenConfig SetEase(EaseType easeType)
        {
            m_Type = easeType;
            return this;
        }

        public TweenConfig SetEase(AnimationCurve animationCurve)
        {
            m_UseAnimationCurve = true;
            m_AnimationCurve = animationCurve;
            return this;
        }

        public TweenConfig TweenCompleteCallback(OnAnimationCompleteCallback callback)
        {
            OnTweenCompleteCallback += callback;
            return this;
        }
    }

    public static class Having
    {
        public static TweenConfig Param = new TweenConfig();
    }
}
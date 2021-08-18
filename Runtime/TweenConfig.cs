using System.Collections;
using System.Collections.Generic;
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

        public void AddCallback(OnAnimationCompleteCallback callback)
        {
            OnTweenCompleteCallback += callback;
        }
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

        public TweenConfig(float durationOrSpeed = 1, bool timeBased = true, float delay = 0, int loopCount = 1, bool pingPong = false, EaseType easeType = EaseType.Linear, bool useAnimationCurve = false, AnimationCurve animationCurve = null, CustomCurve customCurve = null, OnAnimationCompleteCallback tweenCompleteCallback = null)
        {
            m_IsTimeBased = timeBased;
            m_DurationOrSpeed = durationOrSpeed;
            m_Delay = delay;
            m_LoopCount = loopCount;
            m_PingPong = pingPong;
            m_Type = easeType;
            m_UseAnimationCurve = useAnimationCurve;
            m_AnimationCurve = animationCurve;
            OnTweeningComplete = null;
            mCustomCurve = customCurve;
            OnTweenCompleteCallback = tweenCompleteCallback;
            Delta = 0;
        }
    }
}
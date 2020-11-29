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
        public OnAnimationCompleteCallback pOnTweenCompleteCallback { get; private set; }

        public void AddCallback(OnAnimationCompleteCallback callback)
        {
            pOnTweenCompleteCallback += callback;
        }
        public CustomCurve pCustomAnimationCurve
        {
            get
            {
                if (mCustomCurve == null)
                    mCustomCurve = Tween.GetCustomCurve(m_Type);
                return mCustomCurve;
            }
        }

        public float pDurationOrSpeed { get => m_DurationOrSpeed; }
        public float pDelay { get => m_Delay; }
        public int pLoopCount { get => m_LoopCount == 0 ? 1 : m_LoopCount; }
        public bool pPingPong { get => m_PingPong; }
        public EaseType pEaseType { get => m_Type; }
        public bool pUseAnimationCurve { get => m_UseAnimationCurve; }
        public AnimationCurve pAnimationCurve { get => m_AnimationCurve; }
        public bool pIsTimeBased { get => m_IsTimeBased; }
        public float pDelta { get; set; }

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
            pOnTweenCompleteCallback = tweenCompleteCallback;
            pDelta = 0;
        }
    }
}
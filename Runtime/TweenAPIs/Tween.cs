using System;
using UnityEngine;
using UnityEngine.Events;

namespace SAS.TweenManagement
{
    public partial struct Tween
    {
        public static ITween CreateTween(float from, float to, Action<float> onUpdate, ref TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            ITween iTween = new FloatTween(from, to, onUpdate);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Vector2 from, Vector2 to, Action<Vector2> onUpdate, ref TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            ITween iTween = new Vector2Tween(from, to, onUpdate);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Vector3 from, Vector3 to, Action<Vector3> onUpdate, ref TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            ITween iTween = new Vector3Tween(from, to, onUpdate);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Vector4 from, Vector4 to, Action<Vector4> onUpdate, ref TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            ITween iTween = new Vector4Tween(from, to, onUpdate);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CubiceBezier(Transform tweenObject, Vector3 to, Vector3 cp1, Vector3 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            return CubiceBezier(tweenObject, tweenObject.transform.position, to, cp1, cp2, duration, callback);
        }

        public static ITween CubiceBezier(Transform tweenObject, Vector3 from, Vector3 to, Vector3 cp1, Vector3 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = Having.Param.Duration(duration).TweenCompleteCallback(callback);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, cp1, cp2, value); }, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween CubiceBezier(Transform tweenObject, Vector2 to, Vector2 cp1, Vector2 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            return CubiceBezier(tweenObject, (Vector2)tweenObject.transform.position, to, cp1, cp2, duration, callback);
        }

        public static ITween CubiceBezier(Transform tweenObject, Vector2 from, Vector2 to, Vector2 cp1, Vector2 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = Having.Param.Duration(duration).TweenCompleteCallback(callback);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, cp1, cp2, value); }, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector3 to, Vector3 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            return QuadraticBezier(tweenObject, tweenObject.transform.position, to, controlPoint, duration, callback);
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector3 from, Vector3 to, Vector3 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = Having.Param.Duration(duration).TweenCompleteCallback(callback);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, controlPoint, value); }, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector2 to, Vector2 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            return QuadraticBezier(tweenObject, (Vector2)tweenObject.transform.position, to, controlPoint, duration, callback);
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector2 from, Vector2 to, Vector2 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = Having.Param.Duration(duration).TweenCompleteCallback(callback);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, controlPoint, value); }, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        /*
            #region Alpha

                public static void AlphaTo(GameObject tweenObject, float from, float to, TweenParam tweenParam)
                {
                    Alpha(tweenObject, from, to, tweenParam, true);
                }

                public static void AlphaBy(GameObject tweenObject, float from, float to, TweenParam tweenParam)
                {
                    Alpha(tweenObject, from, to, tweenParam, false);
                }

                private static void Alpha(GameObject tweenObject, float from, float to, TweenParam tweenParam, bool isTimeDependent)
                {
                    Renderer rend = tweenObject.GetComponent<Renderer>();
                    if (rend == null)
                    {
                        Debug.Log("================  Renderer Component Not Available ================= "+ tweenObject.name);
                        return;
                    }

                    Tweener tweener = new Alpha(tweenObject, rend, from, to);
                    float deltaMove = GetDeltaMove(from, to, tweenParam._DurationOrSpeed, isTimeDependent);
                    SetTweenParam(tweener, deltaMove, tweenParam);
                }
            #endregion

            #region Text Counter

                public static void TextCounterTo(GameObject tweenObject, float from, float to, TweenParam tweenParam)
                {
                    TextCounter(tweenObject, from, to, tweenParam, true);
                }

                public static void TextCounterBy(GameObject tweenObject, float from, float to, TweenParam tweenParam)
                {
                    TextCounter(tweenObject, from, to, tweenParam, false);
                }

                
           #endregion

                #region Shake

                public static void Shake(GameObject tweenObject, float duration, float shakeAmount, OnAnimationCompleteCallback onAnimationCompleteCallback = null)
                {
                    Tweener tweener = new Shake(tweenObject, shakeAmount);
                    float deltaMove = 1 / duration;
                    tweener.SetData(deltaMove, 0, 1, false, false, null, null, onAnimationCompleteCallback);
                    TweenUpdater.pTweeners.Add(tweener);
                }

                public static void Shake2D(GameObject tweenObject, float duration, float shakeAmount, OnAnimationCompleteCallback onAnimationCompleteCallback = null)
                {
                    Tweener tweener = new Shake2D(tweenObject, shakeAmount);
                    float deltaMove = 1 / duration;
                    tweener.SetData(deltaMove, 0, 1, false, false, null, null ,onAnimationCompleteCallback);
                    TweenUpdater.pTweeners.Add(tweener);
                }

            #endregion
                */
        public static ITween Timer(float time, OnAnimationCompleteCallback onDelayReachesCallback)
        {
            TweenConfig config = Having.Param.Duration(time).TweenCompleteCallback(onDelayReachesCallback); //new TweenConfig(delay, timeBased: true, tweenCompleteCallback: onDelayReachesCallback);
            ITween iTween = CreateTween(0, time, null, ref config);
            iTween.Run();
            return iTween;
        }


        public class Parallel
        {
            private ITween[] _tweens;
            private Action _tweenCompletedCallback;
            private int _completedTweenCount;
            private UnityEvent _animEndCallback;

            public Parallel(in ITween[] tweens, Action callback = null)
            {
                _tweens = tweens;
                _tweenCompletedCallback = callback;
                _completedTweenCount = 0;
            }

            public Parallel(ITween[] tweens, UnityEvent animEndCallback)
            {
                _tweens = tweens;
                _animEndCallback = animEndCallback;
                _completedTweenCount = 0;
            }

            public void Run()
            {
                for (int i = 0; i < _tweens.Length; ++i)
                {
                    TweenRunner.AddCallback(_tweens[i], fun => OnTweenComplete());
                    _tweens[i].Run();
                }
            }

            private void OnTweenComplete()
            {
                if (++_completedTweenCount == _tweens.Length)
                {
                    _tweenCompletedCallback?.Invoke();
                    _animEndCallback?.Invoke();
                }
            }
        }

        public class Sequence
        {
            private ITween[] _tweens;
            private Action _tweenCompletedCallback;
            private int _completedTweenCount;
            public Sequence(in ITween[] tweens, Action callback = null)
            {
                _tweens = tweens;
                _tweenCompletedCallback = callback;
                _completedTweenCount = 0;
            }

            public void Run()
            {
                for (int i = 0; i < _tweens.Length; ++i)
                    TweenRunner.AddCallback(_tweens[i], fun => OnTweenComplete());
                _tweens[_completedTweenCount].Run();
            }

            private void OnTweenComplete()
            {
                if (++_completedTweenCount == _tweens.Length)
                    _tweenCompletedCallback?.Invoke();
                else
                    _tweens[_completedTweenCount].Run();
            }
        }

        #region Helper

        public static CustomCurve GetCustomCurve(EaseType easeType)
        {
            switch (easeType)
            {
                case EaseType.Linear: return EaseCurve.Linear;
                case EaseType.Spring: return EaseCurve.Spring;
                case EaseType.EaseInQuad: return EaseCurve.EaseInQuad;
                case EaseType.EaseOutQuad: return EaseCurve.EaseOutQuad;
                case EaseType.EaseInOutQuad: return EaseCurve.EaseInOutQuad;
                case EaseType.EaseInCubic: return EaseCurve.EaseInCubic;
                case EaseType.EaseOutCubic: return EaseCurve.EaseOutCubic;
                case EaseType.EaseInOutCubic: return EaseCurve.EaseInOutCubic;
                case EaseType.EaseInQuart: return EaseCurve.EaseInQuart;
                case EaseType.EaseOutQuart: return EaseCurve.EaseOutQuart;
                case EaseType.EaseInOutQuart: return EaseCurve.EaseInOutQuart;
                case EaseType.EaseInQuint: return EaseCurve.EaseInQuint;
                case EaseType.EaseOutQuint: return EaseCurve.EaseOutQuint;
                case EaseType.EaseInOutQuint: return EaseCurve.EaseInOutQuint;
                case EaseType.EaseInSine: return EaseCurve.EaseInSine;
                case EaseType.EaseOutSine: return EaseCurve.EaseOutSine;
                case EaseType.EaseInOutSine: return EaseCurve.EaseInOutSine;
                case EaseType.EaseInExpo: return EaseCurve.EaseInExpo;
                case EaseType.EaseOutExpo: return EaseCurve.EaseOutExpo;
                case EaseType.EaseInOutExpo: return EaseCurve.EaseInOutExpo;
                case EaseType.EaseInCirc: return EaseCurve.EaseInCirc;
                case EaseType.EaseOutCirc: return EaseCurve.EaseOutCirc;
                case EaseType.EaseInOutCirc: return EaseCurve.EaseInOutCirc;
                case EaseType.EaseInBounce: return EaseCurve.EaseInBounce;
                case EaseType.EaseOutBounce: return EaseCurve.EaseOutBounce;
                case EaseType.EaseInOutBounce: return EaseCurve.EaseInOutBounce;
                case EaseType.EaseInBack: return EaseCurve.EaseInBack;
                case EaseType.EaseOutBack: return EaseCurve.EaseOutBack;
                case EaseType.EaseInOutBack: return EaseCurve.EaseInOutBack;
                case EaseType.EaseInElastic: return EaseCurve.EaseInElastic;
                case EaseType.EaseOutElastic: return EaseCurve.EaseOutElastic;
                case EaseType.EaseInOutElastic: return EaseCurve.EaseInOutElastic;
                default: return EaseCurve.Linear;

            }
        }

        private static float GetDeltaMove(Vector2 from, Vector2 to, float factor, bool isTimeDepndent)
        {
            return _ = (isTimeDepndent ? 1 / factor : factor / Vector2.Distance(from, to));
        }

        private static float GetDeltaMove(Vector3 from, Vector3 to, float factor, bool isTimeDepndent)
        {
            return _ = (isTimeDepndent ? 1 / factor : factor / Vector3.Distance(from, to));
        }

        private static float GetDeltaMove(Vector4 from, Vector4 to, float factor, bool isTimeDepndent)
        {
            return factor = (isTimeDepndent ? 1 / factor : factor / Vector4.Distance(from, to));
        }

        private static float GetDeltaMove(Quaternion from, Quaternion to, float factor, bool isTimeDepndent)
        {
            return factor = (isTimeDepndent ? 1 / factor : factor / Vector4.Distance(new Vector4(from.x, from.y, from.z, from.w), new Vector4(to.x, to.y, to.z, to.w)));
        }

        private static float GetDeltaMove(float from, float to, float factor, bool isTimeDepndent)
        {
            return factor = (isTimeDepndent ? 1 / factor : factor / Mathf.Abs(from - to));
        }

        #endregion
        public static void PauseAll(bool state)
        {
            TweenRunner.PauseAll(state);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static ITween CreateTween(float from, float to, Action<float> onUpdate, TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            var iTween = ValueTweenPool<float>.Get();
            iTween.Setup(from, to, onUpdate, CustomLerp.Action);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Vector2 from, Vector2 to, Action<Vector2> onUpdate, TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            var iTween = ValueTweenPool<Vector2>.Get();
            iTween.Setup(from, to, onUpdate, CustomLerp.Action);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Vector3 from, Vector3 to, Action<Vector3> onUpdate, TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            var iTween = ValueTweenPool<Vector3>.Get();
            iTween.Setup(from, to, onUpdate, CustomLerp.Action);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Vector4 from, Vector4 to, Action<Vector4> onUpdate, TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            var iTween = ValueTweenPool<Vector4>.Get();
            iTween.Setup(from, to, onUpdate, CustomLerp.Action);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CreateTween(Quaternion from, Quaternion to, Action<Quaternion> onUpdate, TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(from, to, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            var iTween = ValueTweenPool<Quaternion>.Get();
            iTween.Setup(from, to, onUpdate, CustomLerp.Action);
            TweenRunner.Add(iTween, tweenConfig);
            return iTween;
        }

        public static ITween CubicBezier(Transform tweenObject, Vector3 to, Vector3 cp1, Vector3 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            return CubicBezier(tweenObject, tweenObject.transform.position, to, cp1, cp2, duration, callback);
        }

        public static ITween CubicBezier(Transform tweenObject, Vector3 from, Vector3 to, Vector3 cp1, Vector3 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = new TweenConfig().Duration(duration);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, cp1, cp2, value); }, tweenConfig);
            iTween.AddCallback(callback);
            iTween.Run();
            return iTween;
        }

        public static ITween CubicBezier(Transform tweenObject, Vector2 to, Vector2 cp1, Vector2 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            return CubicBezier(tweenObject, (Vector2)tweenObject.transform.position, to, cp1, cp2, duration, callback);
        }

        public static ITween CubicBezier(Transform tweenObject, Vector2 from, Vector2 to, Vector2 cp1, Vector2 cp2, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = new TweenConfig().Duration(duration);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, cp1, cp2, value); }, tweenConfig);
            iTween.AddCallback(callback);
            iTween.Run();
            return iTween;
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector3 to, Vector3 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            return QuadraticBezier(tweenObject, tweenObject.transform.position, to, controlPoint, duration, callback);
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector3 from, Vector3 to, Vector3 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = new TweenConfig().Duration(duration);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, controlPoint, value); }, tweenConfig);
            iTween.AddCallback(callback);
            iTween.Run();
            return iTween;
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector2 to, Vector2 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            return QuadraticBezier(tweenObject, (Vector2)tweenObject.transform.position, to, controlPoint, duration, callback);
        }

        public static ITween QuadraticBezier(Transform tweenObject, Vector2 from, Vector2 to, Vector2 controlPoint, float duration, OnAnimationCompleteCallback callback)
        {
            TweenConfig tweenConfig = new TweenConfig().Duration(duration);
            ITween iTween = CreateTween(0, 1, (value) => { tweenObject.SetPosition(from, to, controlPoint, value); }, tweenConfig);
            iTween.AddCallback(callback);
            iTween.Run();
            return iTween;
        }

        public static ITween CreateTween(Transform tweenObject, float radius, TweenConfig tweenConfig)
        {
            tweenConfig.Delta = GetDeltaMove(0, 360, tweenConfig.DurationOrSpeed, tweenConfig.IsTimeBased);
            var position = tweenObject.transform.localPosition;
            var iTween = new ValueTween<float>();
            iTween.Setup(0, 360, (value) => { tweenObject.SetRadialPosition(position, radius, value); }, CustomLerp.Action);
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
            TweenConfig config = new TweenConfig().Duration(time); //new TweenConfig(delay, timeBased: true, tweenCompleteCallback: onDelayReachesCallback);
            ITween iTween = CreateTween(0, time, null, config);
            iTween.AddCallback(onDelayReachesCallback);
            iTween.Run();
            return iTween;
        }

        public sealed class Parallel
        {
            private ITween[] _tweens;
            private Action _onComplete;

            private int _completedCount;
            private bool _running;

            public Parallel(ITween[] tweens, Action onComplete = null)
            {
                _tweens = tweens;
                _onComplete = onComplete;
                _completedCount = 0;
                _running = false;
            }

            public void Run()
            {
                if (_running)
                    return;

                if (_tweens == null || _tweens.Length == 0)
                {
                    _running = false;
                    _onComplete?.Invoke();
                    return;
                }

                _running = true;
                _completedCount = 0;

                for (int i = 0; i < _tweens.Length; i++)
                {
                    var tween = _tweens[i];
                    TweenRunner.AddCallback(tween, OnTweenComplete);
                    tween.Run();
                }
            }

            private void OnTweenComplete()
            {
                _completedCount++;

                if (_completedCount < _tweens.Length)
                    return;

                for (int i = 0; i < _tweens.Length; i++)
                {
                    TweenRunner.RemoveCallback(_tweens[i], OnTweenComplete);
                }

                _running = false;
                _onComplete?.Invoke();
            }
        }


        public sealed class Sequence
        {
            private const int MaxSteps = 8;

            private readonly ITween[] _steps = new ITween[MaxSteps];
            private int _count;
            private int _index;

            private Action _onSequenceComplete;
            private bool _isRunning;

 
            public Sequence Begin(Action onComplete = null)
            {
                _count = 0;
                _index = 0;
                _onSequenceComplete = onComplete;
                _isRunning = false;
                return this;
            }

            public Sequence Append(ITween tween)
            {
#if UNITY_EDITOR
                if (_count >= MaxSteps)
                    throw new InvalidOperationException("Sequence step limit exceeded");
#endif
                _steps[_count++] = tween;
                return this;
            }


            public void Run()
            {
                if (_isRunning)
                    return;

                if (_count == 0)
                {
                    _isRunning = false;

                    var callback = _onSequenceComplete;
                    _onSequenceComplete = null;
                    callback?.Invoke();

                    SequencePool.Release(this);
                    return;
                }

                _isRunning = true;
                _index = 0;
                PlayCurrent();
            }

            private void PlayCurrent()
            {
                ITween tween = _steps[_index];
                TweenRunner.AddCallback(tween, OnTweenComplete);
                tween.Run();
            }

            private void OnTweenComplete()
            {
                ITween tween = _steps[_index];
                TweenRunner.RemoveCallback(tween, OnTweenComplete);

                if (++_index < _count)
                    PlayCurrent();
                else
                {
                    _isRunning = false;

                    var callback = _onSequenceComplete;
                    _onSequenceComplete = null;
                    callback?.Invoke();

                    SequencePool.Release(this);
                }
            }

            public void Reset()
            {
                for (int i = 0; i < _count; i++)
                    _steps[i] = null;

                _count = 0;
                _index = 0;
                _onSequenceComplete = null;
                _isRunning = false;
            }
        }


        public static class SequencePool
        {
            private static readonly Stack<Sequence> _pool = new();

            public static Sequence Get()
            {
                return _pool.Count > 0
                    ? _pool.Pop()
                    : new Sequence();
            }

            public static void Release(Sequence sequence)
            {
                sequence.Reset();
                _pool.Push(sequence);
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

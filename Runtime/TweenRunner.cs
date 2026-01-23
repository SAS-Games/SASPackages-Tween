using UnityEngine;

namespace SAS.TweenManagement
{
    internal class TweenRunner
    {
        internal static void Add(in TweenBase tween, in TweenConfig tweenConfig)
        {
            tween.Tick = tweenConfig.Tick;

            if (tween.Tick == Tick.UPDATE)
            {
                TweenRunnerUpdate.Instance.Add(tween, tweenConfig);
            }
            else if (tween.Tick == Tick.FIXEDUPDATE)
            {
                TweenRunnerFixedUpdate.Instance.Add(tween, tweenConfig);
            }
        }

        internal static void PauseAll(bool state)
        {
            TweenRunnerUpdate.Instance.enabled = !state;
            TweenRunnerFixedUpdate.Instance.enabled = !state;
        }

        internal static void AddCallback(in TweenBase tween, OnAnimationCompleteCallback callback)
        {
            if (tween.Tick == Tick.UPDATE)
                TweenRunnerUpdate.Instance.AddCallback(tween, callback);
            else if (tween.Tick == Tick.FIXEDUPDATE)
                TweenRunnerFixedUpdate.Instance.AddCallback(tween, callback);
        }

        internal static void RemoveCallback(TweenBase tween, OnAnimationCompleteCallback callback)
        {
            if (tween.Tick == Tick.UPDATE)
                TweenRunnerUpdate.Instance.RemoveCallback(tween, callback);
            else if (tween.Tick == Tick.FIXEDUPDATE)
                TweenRunnerFixedUpdate.Instance.RemoveCallback(tween, callback);
        }

    }

    internal struct TweenArray
    {
        public TweenBase _Tween;
        public TweenConfig _TweenConfig;
        public TweenArray(in TweenBase tween, in TweenConfig tweenConfig)
        {
            _Tween = tween;
            _TweenConfig = tweenConfig;
        }
    }

    internal class TweenRunnerTick<T> : AutoInstantiateSingleton<T> where T : MonoBehaviour
    {
        private const int DEFAULT_CAPACITY = 32;
        protected TweenArray[] mTweens = new TweenArray[DEFAULT_CAPACITY];
        protected int mSize;
        protected float deltaTime;

        protected void EnsureCapacity()
        {
            if (mSize < mTweens.Length)
                return;

            int newCapacity = mTweens.Length * 2;
            var newArray = new TweenArray[newCapacity];
            System.Array.Copy(mTweens, newArray, mTweens.Length);
            mTweens = newArray;
        }

        internal void Add(in TweenBase tween, in TweenConfig config)
        {
            EnsureCapacity();
            mTweens[mSize++] = new TweenArray(tween, config);
        }

        private void RemoveAt(int index)
        {
            mSize--;
            mTweens[index] = mTweens[mSize];
            mTweens[mSize] = default;
        }

        protected void TickTweens()
        {
            for (int i = 0; i < mSize; i++)
            {
                ref TweenArray entry = ref mTweens[i];
                var tween = entry._Tween;

                if (tween.State == TweenState.DONE)
                {
                    CompleteTween(entry);
                    RemoveAt(i--);
                    continue;
                }

                if (tween.State == TweenState.PAUSE ||
                    tween.State == TweenState.NONE)
                    continue;

                UpdateTween(ref entry, ref i);
            }
        }

        private void UpdateTween(ref TweenArray entry, ref int index)
        {
            TweenBase tween = entry._Tween;
            TweenConfig config = entry._TweenConfig;

            if (tween.DelayCounter < config.Delay)
            {
                tween.DelayCounter += deltaTime;
                return;
            }

            tween.Value = Mathf.MoveTowards(tween.Value, 1f, deltaTime * config.Delta);
            float t = tween.Value;
            float eval = config.UseAnimationCurve
                ? config.AnimationCurve.Evaluate(t)
                : config.CustomAnimationCurve(0f, 1f, t);

            tween.DoAnim(tween.DoInReverse ? 1f - eval : eval);

            // Natural completion
            if (t < 1f)
                return;

            tween.Value = 0f;
            tween.CompletedLoopCount++;

            if (config.PingPong)
                tween.DoInReverse = !tween.DoInReverse;

            if (!ShouldComplete(tween, config))
                return;

            tween.State = TweenState.DONE;
            CompleteTween(entry);
            RemoveAt(index--);
        }

        private static bool ShouldComplete(TweenBase tween, in TweenConfig config)
        {
            if (tween.StopOnceCurrentLoopCompleted)
                return true;

            if (config.LoopCount < 0)
                return false;

            int limit;

            if (config.PingPong)
                limit = (config.LoopCount == 1) ? 2 : config.LoopCount * 2;
            else
                limit = config.LoopCount;
            return tween.CompletedLoopCount >= limit;
        }


        private static void CompleteTween(in TweenArray entry)
        {
            var tween = entry._Tween;
            tween.InvokeCallbacks();
            tween.Release();
        }


        internal void AddCallback(in TweenBase tween, OnAnimationCompleteCallback callback)
        {
            for (int i = 0; i < mSize; i++)
            {
                if (ReferenceEquals(mTweens[i]._Tween, tween))
                {
                    mTweens[i]._Tween.AddCallback(callback);
                    return;
                }
            }
        }

        internal void RemoveCallback(TweenBase tween, OnAnimationCompleteCallback callback)
        {
            for (int i = 0; i < mSize; i++)
            {
                if (ReferenceEquals(mTweens[i]._Tween, tween))
                {
                    mTweens[i]._Tween.RemoveCallback(callback);
                    return;
                }
            }
        }

    }
}

using SAS.Utilities;
using System;
using UnityEngine;

namespace SAS.TweenManagement
{
    internal class TweenRunner
    {
        internal static void Add(in ITween tween, in TweenConfig tweenConfig)
        {
            tween.Tick = tweenConfig.Tick;
            if (tween.Tick == Tick.UPDATE)
            {
                var instance = TweenRunnerUpdate.Instance;
                instance.EnsureCapacity();
                instance.mTweens[instance.mSize++] = new TweenArray(tween, tweenConfig);
            }
            else if (tweenConfig.Tick == Tick.FIXEDUPDATE)
            {
                var instance = TweenRunnerFixedUpdate.Instance;
                instance.EnsureCapacity();
                instance.mTweens[instance.mSize++] = new TweenArray(tween, tweenConfig);
            }
        }

        internal static void PauseAll(bool state)
        {
            TweenRunnerUpdate.Instance.enabled = !state;
            TweenRunnerFixedUpdate.Instance.enabled = !state;
        }

        internal static void AddCallback(in ITween tween, OnAnimationCompleteCallback callback)
        {
            if (tween.Tick == Tick.UPDATE)
                TweenRunnerUpdate.Instance.AddCallback(tween, callback);
            else if (tween.Tick == Tick.FIXEDUPDATE)
                TweenRunnerFixedUpdate.Instance.AddCallback(tween, callback);
        }
    }
    internal struct TweenArray
    {
        public ITween _Tween;
        public TweenConfig _TweenConfig;
        public TweenArray(in ITween tween, in TweenConfig tweenConfig)
        {
            _Tween = tween;
            _TweenConfig = tweenConfig;
        }
    }

    internal class TweenRunnerTick<T> : AutoInstantiateSingleton<T> where T : MonoBehaviour
    {
        internal protected ushort mSize = 0;
        internal protected float deltaTime = 0;
        private float mValue = 0;
        private ushort mCapacity = 4;

        internal protected TweenArray[] mTweens = new TweenArray[4];

        internal void EnsureCapacity()
        {
            if (mSize >= mCapacity)
            {
                TweenArray[] newItems = new TweenArray[mCapacity *= 2];
                if (mSize > 0)
                    Array.Copy(mTweens, 0, newItems, 0, mSize);
                mTweens = newItems;
            }
        }


        private void Remove(in ITween tween)
        {
            ushort index = IndexOf(mTweens, tween);
            if (index >= 0)
            {
                --mSize;
                if (index < mSize)
                    Array.Copy(mTweens, index + 1, mTweens, index, mSize - index);
                mTweens[mSize] = default(TweenArray);
            }
        }

        private ushort IndexOf(in TweenArray[] array, in ITween tween)
        {
            for (ushort i = 0; i < ushort.MaxValue; i++)
            {
                if (tween == array[i]._Tween)
                    return i;
            }
            return ushort.MaxValue;
        }

        protected void DoUpdate(in ITween tween, in TweenConfig param)
        {
            if (tween.State == TweenState.PAUSE || tween.State == TweenState.NONE)
                return;
            if (tween.State == TweenState.DONE)
            {
                Remove(tween);
                return;
            }

            if (tween.DelayCounter < param.Delay)
            {
                tween.DelayCounter += deltaTime;
                return;
            }

            tween.Value = Mathf.MoveTowards(tween.Value, 1, deltaTime * param.Delta);
            if (param.UseAnimationCurve)
                mValue = param.AnimationCurve.Evaluate(tween.Value);
            else
                mValue = param.CustomAnimationCurve(0, 1, tween.Value);

            tween.DoAnim(!tween.DoInReverese ? mValue : 1 - mValue);

            if (tween.Value >= 1)
            {
                tween.Value = 0;
                tween.DoInReverese = param.PingPong ? !tween.DoInReverese : tween.DoInReverese;
                ++tween.CompletedLoopCount;

                if (tween.StopOnceCurrentLoopCompleted || !(tween.CompletedLoopCount != (param.PingPong ? param.LoopCount != 1 ? 2 * param.LoopCount : 2 : param.LoopCount)))
                {
                    tween.State = TweenState.DONE;
                    param.OnTweeningComplete?.Invoke();
                    param.OnTweenCompleteCallback?.Invoke(null);
                    Remove(tween);
                }
            }
        }

        internal void AddCallback(in ITween tween, OnAnimationCompleteCallback callback)
        {
            for (int i = 0; i < mTweens.Length; ++i)
            {
                if (mTweens[i]._Tween != null && mTweens[i]._Tween.Equals(tween))
                    mTweens[i]._TweenConfig.TweenCompleteCallback(callback);
            }
        }
    }
}

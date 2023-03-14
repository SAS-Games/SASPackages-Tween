using UnityEngine;
using System;
using SAS.Utilities;

namespace SAS.TweenManagment
{
    internal sealed class TweenRunner : AutoInstantiateSingleton<TweenRunner>
    {
        struct TweenArray
        {
            public ITween _Tween;
            public TweenConfig _TweenConfig;
            public TweenArray(in ITween tween, in TweenConfig tweenConfig)
            {
                _Tween = tween;
                _TweenConfig = tweenConfig;
            }
        }

        private float mValue = 0;
        private ushort mSize = 0;
        private ushort mCapacity = 4;

        private TweenArray[] mTweens = new TweenArray[4];

        internal static void Add(in ITween tween, in TweenConfig tweenConfig)
        {
            Instance.EnsureCapacity();
            Instance.mTweens[Instance.mSize++] = new TweenArray(tween, tweenConfig);
        }

        private void EnsureCapacity()
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
            ushort index = IndexOf(mTweens,  tween);
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


        float deltaTime = 0;
        private void Update()
        {
            deltaTime = Time.deltaTime;
            for (int i = 0; i < mSize; ++i)
                DoUpdate(mTweens[i]._Tween, mTweens[i]._TweenConfig);
        }

        private void DoUpdate(in ITween tween, in TweenConfig param)
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

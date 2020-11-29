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

        public static void Add(in ITween tween, in TweenConfig tweenConfig)
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
            if (tween.pState == TweenState.PAUSE || tween.pState == TweenState.NONE)
                return;
            if (tween.pState == TweenState.DONE)
            {
                Remove(tween);
                return;
            }

            if (tween.pDelayCounter < param.pDelay)
            {
                tween.pDelayCounter += deltaTime;
                return;
            }

            tween.pValue = Mathf.MoveTowards(tween.pValue, 1, deltaTime * param.pDelta);

            if (param.pUseAnimationCurve)
                mValue = param.pAnimationCurve.Evaluate(tween.pValue);
            else
                mValue = param.pCustomAnimationCurve(0, 1, tween.pValue);

            tween.DoAnim(!tween.pDoInReverese ? mValue : 1 - mValue);

            if (tween.pValue >= 1)
            {
                tween.pValue = 0;
                tween.pDoInReverese = param.pPingPong ? !tween.pDoInReverese : tween.pDoInReverese;
                ++tween.pCompletedLoopCount;

                if (!(tween.pCompletedLoopCount != (param.pPingPong ? param.pLoopCount != 1 ? 2 * param.pLoopCount : 2 : param.pLoopCount)))
                {
                    tween.pState = TweenState.DONE;
                    param.OnTweeningComplete?.Invoke();
                    param.pOnTweenCompleteCallback?.Invoke(null);
                    Remove(tween);
                }
            }
        }

        internal void AddCallback(in ITween tween, OnAnimationCompleteCallback callback)
        {
            for (int i = 0; i < mTweens.Length; ++i)
            {
                if (mTweens[i]._Tween != null && mTweens[i]._Tween == tween)
                    mTweens[i]._TweenConfig.AddCallback(callback);
            }
        }
    }
}

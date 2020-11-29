using System;
using UnityEngine;

namespace SAS.TweenManagment
{
    public struct Vector4Tween : ITween
    {
        float ITween.pDelayCounter { get; set; }
        bool ITween.pDoInReverese { get; set; }
        short ITween.pCompletedLoopCount { get; set; }
        float ITween.pValue { get; set; }
        public TweenState pState { get; set; }

        private Action<Vector4> mOnUpdate { get; set; }

        private Vector4 mFrom;
        private Vector4 mTo;

        public Vector4Tween(Vector4 from, Vector4 to, Action<Vector4> upateAction) : this()
        {
            mFrom = from;
            mTo = to;
            mOnUpdate = upateAction;
        }

        void ITween.DoAnim(float val) => mOnUpdate(CustomLerp.Action(mFrom, mTo, val));
        public void Run() => pState = TweenState.RUN;
        public void Pause() => pState = TweenState.PAUSE;
        public void Stop() => pState = TweenState.DONE;
    }
}


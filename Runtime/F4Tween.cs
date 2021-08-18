using System;
using UnityEngine;

namespace SAS.TweenManagment
{
    public struct Vector4Tween : ITween
    {
        float ITween.DelayCounter { get; set; }
        bool ITween.DoInReverese { get; set; }
        public bool StopOnceCurrentLoopCompleted { get; set; }
        short ITween.CompletedLoopCount { get; set; }
        float ITween.Value { get; set; }
        public TweenState State { get; set; }

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
        public void Run() => State = TweenState.RUN;
        public void Pause() => State = TweenState.PAUSE;
        public void Stop(bool immediate)
        {
            if (immediate)
                StopOnceCurrentLoopCompleted = true;
            else
                State = TweenState.DONE;
        }
    }
}


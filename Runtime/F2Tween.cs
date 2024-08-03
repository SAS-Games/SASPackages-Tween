
using System;
using UnityEngine;

namespace SAS.TweenManagement
{
    public struct Vector2Tween : ITween
    {
        float ITween.DelayCounter { get; set; }
        bool ITween.DoInReverese { get; set; }
        public bool StopOnceCurrentLoopCompleted { get; set; }
        short ITween.CompletedLoopCount { get; set; }
        float ITween.Value { get; set; }
        public TweenState State { get; set; }
        public Tick Tick { get; set; }

        private Action<Vector2> mOnUpdate { get; set; }
        private Vector2 mFrom;
        private Vector2 mTo;

        public Vector2Tween(Vector2 from, Vector2 to, Action<Vector2> upateAction) : this()
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


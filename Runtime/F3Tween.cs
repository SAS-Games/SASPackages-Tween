
using System;
using UnityEngine;

namespace SAS.TweenManagement
{
    public struct Vector3Tween : ITween
    {
        float ITween.DelayCounter { get; set; }
        bool ITween.DoInReverese { get; set; }
        public bool StopOnceCurrentLoopCompleted { get; set; }
        short ITween.CompletedLoopCount { get; set; }
        float ITween.Value { get; set; }
        public TweenState State { get; set; }
        public Tick Tick { get; set; }

        private Action<Vector3> mOnUpdate { get; set; }
        private Vector3 mFrom;
        private Vector3 mTo;

        public Vector3Tween(Vector3 from, Vector3 to, Action<Vector3> upateAction) : this()
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


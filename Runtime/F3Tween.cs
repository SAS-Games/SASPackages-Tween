
using System;
using UnityEngine;

namespace SAS.TweenManagment
{
    public struct Vector3Tween : ITween
    {
        float ITween.pDelayCounter { get; set; }
        bool ITween.pDoInReverese { get; set; }
        short ITween.pCompletedLoopCount { get; set; }
        float ITween.pValue { get; set; }
        public TweenState pState { get; set; }

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
        public void Run() => pState = TweenState.RUN;
        public void Pause() => pState = TweenState.PAUSE;
        public void Stop() => pState = TweenState.DONE;
    }
}


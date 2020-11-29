
using System;
using UnityEngine;

namespace SAS.TweenManagment
{
    public struct Vector2Tween : ITween
    {
        float ITween.pDelayCounter { get; set; }
        bool ITween.pDoInReverese { get; set; }
        short ITween.pCompletedLoopCount { get; set; }
        float ITween.pValue { get; set; }
        public TweenState pState { get; set; }

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
        public void Run() => pState = TweenState.RUN;
        public void Pause() => pState = TweenState.PAUSE;
        public void Stop() => pState = TweenState.DONE;
    }
}


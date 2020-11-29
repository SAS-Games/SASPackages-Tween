using System;

namespace SAS.TweenManagment
{
    public struct FloatTween : ITween
    {
        float ITween.pDelayCounter { get; set; }
        bool ITween.pDoInReverese { get; set; }
        short ITween.pCompletedLoopCount { get; set; }
        float ITween.pValue { get; set; }
        public TweenState pState { get; set; }

        private Action<float> mOnUpdate { get; set; }

        private float mFrom;
        private float mTo;

        public FloatTween(float from, float to, Action<float> upateAction) : this()
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


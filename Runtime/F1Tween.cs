using System;

namespace SAS.TweenManagement
{
    public struct FloatTween : ITween
    {
        float ITween.DelayCounter { get; set; }
        bool ITween.DoInReverse { get; set; }
        public bool StopOnceCurrentLoopCompleted { get; set; }
        short ITween.CompletedLoopCount { get; set; }
        float ITween.Value { get; set; }
        public TweenState State { get; set; }
        public Tick Tick { get ; set; }

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


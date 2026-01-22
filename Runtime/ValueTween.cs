using System;

namespace SAS.TweenManagement
{
    public sealed class ValueTween<T> : ITween
    {
        public float DelayCounter { get; set; }
        public bool DoInReverse { get; set; }
        public bool StopOnceCurrentLoopCompleted { get; set; }
        public int CompletedLoopCount { get; set; }
        public float Value { get; set; }
        public TweenState State { get; set; }
        public Tick Tick { get; set; }

    private T _from;
        private T _to;
        private Action<T> _onUpdate;
        private Func<T, T, float, T> _lerp;

        public void Setup(T from, T to, Action<T> onUpdate, Func<T, T, float, T> lerp)
        {
            _from = from;
            _to = to;
            _onUpdate = onUpdate;
            _lerp = lerp;

            State = TweenState.NONE;
            Value = 0f;
            DelayCounter = 0f;
            CompletedLoopCount = 0;
            DoInReverse = false;
            StopOnceCurrentLoopCompleted = false;
        }

        public void DoAnim(float t)
        {
            _onUpdate(_lerp(_from, _to, t));
        }

        public void Run() => State = TweenState.RUN;
        public void Pause() => State = TweenState.PAUSE;

        public void Stop(bool immediate)
        {
            if (immediate)
                State = TweenState.DONE;
            else
                StopOnceCurrentLoopCompleted = true;
        }

        public void Reset()
        {
            State = TweenState.NONE;
            Value = 0f;
            DelayCounter = 0f;
            CompletedLoopCount = 0;
            DoInReverse = false;
            StopOnceCurrentLoopCompleted = false;
        }

        public void Release()
        {
            ValueTweenPool<T>.Release(this);
        }

        private event OnAnimationCompleteCallback _onComplete;

        public void AddCallback(OnAnimationCompleteCallback callback)
        {
            _onComplete += callback;
        }

        public void RemoveCallback(OnAnimationCompleteCallback callback)
        {
            _onComplete -= callback;
        }

        public void InvokeCallbacks()
        {
            _onComplete?.Invoke();
            _onComplete = null; // important: avoid leaks when pooled
        }
    }
}

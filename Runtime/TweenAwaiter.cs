using System;
using System.Runtime.CompilerServices;

namespace SAS.TweenManagement
{
    public class TweenAwaiter : INotifyCompletion
    {
        private ITween _itween;
        private bool _isCompleted;
        private Action _continuation;

        public TweenAwaiter(ITween itween)
        {
            _itween = itween;
            _isCompleted = false;
            if (itween.Tick == Tick.UPDATE)
            {
                TweenRunnerUpdate.Instance.AddCallback(_itween, ele =>
                {
                    IsCompleted = _itween.State == TweenState.DONE;
                });
            }
            else if (itween.Tick == Tick.FIXEDUPDATE)
            {
                TweenRunnerFixedUpdate.Instance.AddCallback(_itween, ele =>
                {
                    IsCompleted = _itween.State == TweenState.DONE;
                });
            }
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            protected set
            {
                _isCompleted = value;

                if (value)
                {
                    _continuation?.Invoke();
                    _continuation = null;
                }
            }
        }

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
        }

        public ITween GetResult()
        {
            return _itween;
        }
    }
}

using System;

namespace SAS.TweenManagement
{
    public sealed class ValueTween<T> : TweenBase
    {
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

            ResetState();
        }

        public override void DoAnim(float t)
        {
            _onUpdate(_lerp(_from, _to, t));
        }

        public override void Release()
        {
            _onUpdate = null;
            _lerp = null;
            ValueTweenPool<T>.Release(this);
        }
    }
}
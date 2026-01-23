using System.Collections.Generic;

namespace SAS.TweenManagement
{
    internal static class ValueTweenPool<T>
    {
        private static readonly Stack<ValueTween<T>> Pool = new Stack<ValueTween<T>>(128);

        public static void WarmUp(int count)
        {
            for (int i = Pool.Count; i < count; i++)
                Pool.Push(new ValueTween<T>());
        }

        public static ValueTween<T> Get()
        {
            return Pool.Count > 0 ? Pool.Pop() : new ValueTween<T>();
        }

        public static void Release(ValueTween<T> tween)
        {
            tween.ResetState();
            Pool.Push(tween);
        }
    }
}

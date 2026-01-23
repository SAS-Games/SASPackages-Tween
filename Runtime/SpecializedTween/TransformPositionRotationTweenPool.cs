using System.Collections.Generic;

namespace SAS.TweenManagement
{
    internal static class TransformPositionRotationTweenPool
    {
        private static readonly Stack<TransformPositionRotationTween> _pool = new();

        public static TransformPositionRotationTween Get()
        {
            return _pool.Count > 0
                ? _pool.Pop()
                : new TransformPositionRotationTween();
        }

        public static void Release(TransformPositionRotationTween tween)
        {
            _pool.Push(tween);
        }
    }
}
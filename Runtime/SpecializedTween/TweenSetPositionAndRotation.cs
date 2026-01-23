using UnityEngine;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static TweenBase SetPositionAndRotation(Transform transform, Vector3 toPosition, Quaternion toRotation, TweenConfig config)
        {
            Vector3 fromPos = transform.position;
            Quaternion fromRot = transform.rotation;

            config.Delta = GetDeltaMove(0f, 1f, config.DurationOrSpeed, config.IsTimeBased);

            var tween = TransformPositionRotationTweenPool.Get();

            tween.Setup(transform, fromPos, toPosition, fromRot, toRotation, false);

            TweenRunner.Add(tween, config);
            tween.Run();
            return tween;
        }
        
        public static TweenBase SetLocalPositionAndRotation(Transform transform, Vector3 toPosition, Quaternion toRotation, TweenConfig config)
        {
            Vector3 fromPos = transform.position;
            Quaternion fromRot = transform.rotation;

            config.Delta = GetDeltaMove(0f, 1f, config.DurationOrSpeed, config.IsTimeBased);

            var tween = TransformPositionRotationTweenPool.Get();

            tween.Setup(transform, fromPos, toPosition, fromRot, toRotation, true);

            TweenRunner.Add(tween, config);
            tween.Run();
            return tween;
        }
    }
}
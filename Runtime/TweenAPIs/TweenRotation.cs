using UnityEngine;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static TweenBase EulerAngles(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return EulerAngles(tweenObject, tweenObject.eulerAngles, to, tweenConfig);
        }

        public static TweenBase EulerAngles(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetEulerAngles, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase LocalEulerAngles(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return LocalEulerAngles(tweenObject, tweenObject.localEulerAngles, to, tweenConfig);
        }

        public static TweenBase LocalEulerAngles(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetLocalEulerAngles, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase Rotation(Transform tweenObject, Quaternion to, TweenConfig tweenConfig)
        {
            return Rotation(tweenObject, tweenObject.rotation, to, tweenConfig);
        }

        public static TweenBase Rotation(Transform tweenObject, Quaternion from, Quaternion to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetRotation, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase LocalRotation(Transform tweenObject, Quaternion to, TweenConfig tweenConfig)
        {
            return LocalRotation(tweenObject, tweenObject.localRotation, to, tweenConfig);
        }

        public static TweenBase LocalRotation(Transform tweenObject, Quaternion from, Quaternion to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetLocalRotation, tweenConfig);
            iTween.Run();
            return iTween;
        }

    }
}

using UnityEngine;

namespace SAS.TweenManagment
{
    public partial struct Tween
    {
        public static ITween EulerAngles(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return EulerAngles(tweenObject, to, ref tweenConfig);
        }

        public static ITween EulerAngles(Transform tweenObject, Vector3 to, ref TweenConfig tweenConfig)
        {
            return EulerAngles(tweenObject, tweenObject.eulerAngles, to, ref tweenConfig);
        }

        public static ITween EulerAngles(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            return EulerAngles(tweenObject, tweenObject.eulerAngles, to, ref tweenConfig);
        }

        public static ITween EulerAngles(Transform tweenObject, Vector3 from, Vector3 to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, tweenObject.SetEulerAngles, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween LocalEulerAngles(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return LocalEulerAngles(tweenObject, to, ref tweenConfig);
        }

        public static ITween LocalEulerAngles(Transform tweenObject, Vector3 to, ref TweenConfig tweenConfig)
        {
            return LocalEulerAngles(tweenObject, tweenObject.localEulerAngles, to, ref tweenConfig);
        }

        public static ITween LocalEulerAngles(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            return LocalEulerAngles(tweenObject, from, to, ref tweenConfig);
        }

        public static ITween LocalEulerAngles(Transform tweenObject, Vector3 from, Vector3 to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, tweenObject.SetLocalEulerAngles, ref tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}

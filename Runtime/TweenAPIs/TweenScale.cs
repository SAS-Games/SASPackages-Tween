using UnityEngine;

namespace SAS.TweenManagment
{
    public partial struct Tween
    {
        public static ITween Scale(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return Scale(tweenObject, to, ref tweenConfig);
        }

        public static ITween Scale(Transform tweenObject, Vector3 to, ref TweenConfig tweenConfig)
        {
            return Scale(tweenObject, tweenObject.localScale, to, ref tweenConfig);
        }

        public static ITween Scale(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            return Scale(tweenObject, from, to, ref tweenConfig);
        }

        public static ITween Scale(Transform tweenObject, Vector3 from, Vector3 to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, tweenObject.SetLocalScale, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween Scale(Transform tweenObject, Vector2 to, TweenConfig tweenConfig)
        {
            return Scale(tweenObject, to, ref tweenConfig);
        }

        public static ITween Scale(Transform tweenObject, Vector2 to, ref TweenConfig tweenConfig)
        {
            return Scale(tweenObject, (Vector2)tweenObject.localScale, to, ref tweenConfig);
        }

        public static ITween Scale(Transform tweenObject, Vector2 from, Vector2 to, TweenConfig tweenConfig)
        {
            return Scale(tweenObject, from, to, ref tweenConfig);
        }

        public static ITween Scale(Transform tweenObject, Vector2 from, Vector2 to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, tweenObject.SetLocalScale, ref tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}

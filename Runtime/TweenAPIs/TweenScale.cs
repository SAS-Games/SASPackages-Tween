using UnityEngine;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static TweenBase Scale(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return Scale(tweenObject, tweenObject.localScale, to, tweenConfig);
        }

        public static TweenBase Scale(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetLocalScale, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase Scale(Transform tweenObject, Vector2 to, TweenConfig tweenConfig)
        {
            return Scale(tweenObject, (Vector2)tweenObject.localScale, to, tweenConfig);
        }

        public static TweenBase Scale(Transform tweenObject, Vector2 from, Vector2 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetLocalScale, tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}

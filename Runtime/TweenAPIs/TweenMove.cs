using UnityEngine;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static TweenBase Move(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return Move(tweenObject, tweenObject.position, to, tweenConfig);
        }

        public static TweenBase Move(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetPosition, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase MoveLocal(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return MoveLocal(tweenObject, tweenObject.localPosition, to, tweenConfig);
        }

        public static TweenBase MoveLocal(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetLocalPosition, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase RigidbodyMove(Rigidbody tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return RigidbodyMove(tweenObject, tweenObject.position, to, tweenConfig);
        }

        public static TweenBase RigidbodyMove(Rigidbody tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, tweenObject.SetPosition, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase RadialMove(Transform tweenObject, float radius, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(tweenObject, radius, tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}

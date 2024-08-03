using UnityEngine;

namespace SAS.TweenManagement
{
    public partial struct Tween
    {
        public static ITween Move(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return Move(tweenObject, to, ref tweenConfig);
        }

        public static ITween Move(Transform tweenObject, Vector3 to, ref TweenConfig tweenConfig)
        {
            return Move(tweenObject, tweenObject.position, to, ref tweenConfig);
        }

        public static ITween Move(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            return Move(tweenObject, from, to, ref tweenConfig);
        }

        public static ITween Move(Transform tweenObject, Vector3 from, Vector3 to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, tweenObject.SetPosition, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween MoveLocal(Transform tweenObject, Vector3 to, TweenConfig tweenConfig)
        {
            return MoveLocal(tweenObject, to, ref tweenConfig);
        }

        public static ITween MoveLocal(Transform tweenObject, Vector3 to, ref TweenConfig tweenConfig)
        {
            return MoveLocal(tweenObject, tweenObject.localPosition, to, ref tweenConfig);
        }

        public static ITween MoveLocal(Transform tweenObject, Vector3 from, Vector3 to, TweenConfig tweenConfig)
        {
            return MoveLocal(tweenObject, from, to, ref tweenConfig);
        }

        public static ITween MoveLocal(Transform tweenObject, Vector3 from, Vector3 to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, tweenObject.SetLocalPosition, ref tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}

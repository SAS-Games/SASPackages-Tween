using UnityEngine;

namespace SAS.TweenManagment
{
    public static class Bezier
    {
        public static Vector3 CubicPoint(Vector3 from, Vector3 to, Vector3 controlPoint1, Vector3 controlPoint2, float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            Vector3 p = uuu * from + 3 * uu * t * controlPoint1 + 3 * u * tt * controlPoint2 + ttt * to;

            return p;
        }

        public static Vector2 CubicPoint(Vector2 from, Vector2 to, Vector2 controlPoint1, Vector2 controlPoint2, float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            Vector2 p = uuu * from + 3 * uu * t * controlPoint1 + 3 * u * tt * controlPoint2 + ttt * to;

            return p;
        }

        public static Vector3 QuadraticPoint(Vector3 from, Vector3 to, Vector3 controlPoint, float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;

            Vector2 p = (uu * from) + (2 * u * t * controlPoint) + (tt * to);

            return p;
        }

        public static Vector2 QuadraticPoint(Vector2 from, Vector2 to, Vector2 controlPoint, float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;

            Vector2 p = (uu * from) + (2 * u * t * controlPoint) + (tt * to);

            return p;
        }

        internal static void SetPosition(this Transform transform, Vector3 from, Vector3 to, Vector3 controlPoint1, Vector3 controlPoint2, float t)
        {
            transform.position = CubicPoint(from, to, controlPoint1, controlPoint2, t);
        }

        internal static void SetPosition(this Transform transform, Vector2 from, Vector2 to, Vector2 controlPoint1, Vector2 controlPoint2, float t)
        {
            transform.position = CubicPoint(from, to, controlPoint1, controlPoint2, t);
        }

        internal static void SetLocalPosition(this Transform transform, Vector3 from, Vector3 to, Vector3 controlPoint1, Vector3 controlPoint2, float t)
        {
            transform.localPosition = CubicPoint(from, to, controlPoint1, controlPoint2, t);
        }

        internal static void SetLocalPosition(this Transform transform, Vector2 from, Vector2 to, Vector2 controlPoint1, Vector2 controlPoint2, float t)
        {
            transform.localPosition = CubicPoint(from, to, controlPoint1, controlPoint2, t);
        }

        internal static void SetPosition(this Transform transform, Vector3 from, Vector3 to, Vector3 controlPoint, float t)
        {
            transform.position = QuadraticPoint(from, to, controlPoint, t);
        }
        internal static void SetPosition(this Transform transform, Vector2 from, Vector2 to, Vector2 controlPoint, float t)
        {
            transform.position = QuadraticPoint(from, to, controlPoint, t);
        }

        internal static void SetLocalPosition(this Transform transform, Vector3 from, Vector3 to, Vector3 controlPoint, float t)
        {
            transform.localPosition = QuadraticPoint(from, to, controlPoint, t);
        }
        internal static void SetLocalPosition(this Transform transform, Vector2 from, Vector2 to, Vector2 controlPoint, float t)
        {
            transform.localPosition = QuadraticPoint(from, to, controlPoint, t);
        }
    }
}

using UnityEngine;

namespace SAS.TweenManagment
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/CubicBezierTweenConfigV2")]

    public class CubicBezierTweenConfigV2 : ScriptableObject
    {
        [SerializeField] private float m_Duration;
        [SerializeField] private Vector2 m_ControlPoint1;
        [SerializeField] private Vector2 m_ControlPoint2;

        public float Duration => m_Duration;
        public Vector2 ControlPoint1 => m_ControlPoint1;
        public Vector2 ControlPoint2 => m_ControlPoint2;
    }
}
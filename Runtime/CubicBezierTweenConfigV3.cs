using UnityEngine;

namespace SAS.TweenManagment
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/CubicBezierTweenConfigV3")]

    public class CubicBezierTweenConfigV3 : ScriptableObject
    {
        [SerializeField] private float m_Duration;
        [SerializeField] private Vector3 m_ControlPoint1;
        [SerializeField] private Vector3 m_ControlPoint2;

        public float Duration => m_Duration;
        public Vector3 ControlPoint1 => m_ControlPoint1;
        public Vector3 ControlPoint2 => m_ControlPoint2;
    }
}
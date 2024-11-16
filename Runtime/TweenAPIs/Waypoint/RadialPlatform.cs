using UnityEngine;

namespace SAS.TweenManagement.Waypoints
{
    public class RadialPlatform : MonoBehaviour
    {
        [SerializeField] private Transform m_Platform;
        [SerializeField] private float m_Radius = 5;
        [SerializeField] private TweenConfig m_TweenConfig;
        private ITween _tween;

        void Start()
        {
            _tween = Tween.RadialMove(m_Platform, m_Radius, ref m_TweenConfig);
        }

        private void OnDestroy()
        {
            _tween.Stop(false);
        }

        private void HandleOnTriggerEnter(Collider other)
        {
            other.transform.SetParent(m_Platform, true);
        }

        private void HandleOnTriggerExit(Collider other)
        {
            other.transform.SetParent(null);
        }
    }
}

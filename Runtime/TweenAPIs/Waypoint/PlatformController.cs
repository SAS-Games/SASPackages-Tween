using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SAS.TweenManagement.Waypoints
{
    public enum WaypointBehaviorType
    {
        Loop,
        PingPong,
        SinglePass,
    }

    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private List<Vector3> m_Waypoints = new List<Vector3>();

        [SerializeField] private WaypointBehaviorType m_BehaviorType = WaypointBehaviorType.Loop;
        [SerializeField] private EaseType m_EaseType = default;


        [SerializeField] private Transform m_Platform;
        [SerializeField] private bool m_AutoActivate = true;
        public int startIndex = 0;
        [SerializeField] private float m_Speed = 3f; // Speed of movement
        [SerializeField] private float m_delay = 0.2f;
        [SerializeField] private bool m_MoveTowardsPath = true;
        [SerializeField] private bool m_LocalSpace = true;
        [SerializeField] private Tick m_Tick;


        private IEnumerator<int> _currentPointIndex;
        private TweenConfig _config;
        private ITween _tween;
        private bool _activated = false;

        private void Start()
        {
            if (m_Waypoints.Count < 2)
            {
                Debug.LogError($"Path should contains minimum 2 points");
                return;
            }

            if (m_AutoActivate)
                StartMovment();
        }

        private void CreatePath()
        {
            IWaypointCollection waypointCollection = null;

            if (m_BehaviorType is WaypointBehaviorType.Loop)
                waypointCollection = new Cyclic(m_Waypoints.Count, startIndex);
            else if (m_BehaviorType == WaypointBehaviorType.PingPong)
                waypointCollection = new PingPong(m_Waypoints.Count, startIndex);
            else
                waypointCollection = new SinglePass(m_Waypoints.Count, startIndex);

            _currentPointIndex = waypointCollection.GetWaypointEnumerator();
            _currentPointIndex.MoveNext();
        }

        private void StartMovment()
        {
            if (_activated)
                return;
            _activated = true;

            CreatePath();

            if (!m_MoveTowardsPath)
            {
                var position = m_Waypoints[_currentPointIndex.Current];
                _currentPointIndex.MoveNext();
                if (m_LocalSpace)
                    m_Platform.localPosition = position;
                else
                    m_Platform.position = position;
            }
            _config = new TweenConfig().Speed(m_Speed).WithDelay(m_delay).SetEase(m_EaseType).UseTick(m_Tick);
            _ = MoveAsync(_currentPointIndex.Current);
        }

        private async Task MoveAsync(int i)
        {
            if (this != null)
            {
                if (m_LocalSpace)
                    _tween = Tween.MoveLocal(m_Platform, m_Waypoints[i], ref _config);
                else
                    _tween = Tween.Move(m_Platform, m_Waypoints[i], ref _config);
                await _tween;
                if (_currentPointIndex.MoveNext())
                    _ = MoveAsync(_currentPointIndex.Current);
            }
        }

        private void OnDestroy()
        {
            _tween?.Stop(false);
            _activated = false;
        }

        private void HandleOnTriggerEnter(Collider other)
        {
            other.transform.SetParent(m_Platform, true);

        }

        private void HandleOnTriggerExit(Collider other)
        {
            other.transform.SetParent(null);
            other.SendMessage("SetSceneToOriginal", SendMessageOptions.DontRequireReceiver);
        }

        void ActivatePlatform()
        {
            StartMovment();
        }
    }
}

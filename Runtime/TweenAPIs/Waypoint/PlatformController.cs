using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SAS.TweenManagement.Waypoints
{
    public enum WaypointBehaviorType
    {
        Loop,
        PingPong
    }

    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private List<Vector3> m_Waypoints = new List<Vector3>();

        [SerializeField] private WaypointBehaviorType m_BehaviorType = WaypointBehaviorType.Loop;
        [SerializeField] private EaseType m_EaseType = default;


        [SerializeField] private float m_Speed = 3f; // Speed of movement
        [SerializeField] private bool m_MoveTowardsPath = true;
        [SerializeField] private Transform m_Platform;
        [SerializeField] private bool m_LocalSpace = true;
        [SerializeField] private Tick m_Tick;


        private IEnumerator<int> _currentPointIndex;
        private TweenConfig _config;
        private ITween _tween;

        private void Start()
        {
            if (m_Waypoints.Count < 2)
            {
                Debug.LogError($"Path should contains minimum 2 points");
                return;
            }
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
            _config = Having.Param.Speed(m_Speed).SetEase(m_EaseType).UseTick(m_Tick);
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
                _currentPointIndex.MoveNext();
                _ = MoveAsync(_currentPointIndex.Current);
            }
        }

        private void CreatePath()
        {
            IWaypointCollection waypointCollection = null;

            if (m_BehaviorType is WaypointBehaviorType.Loop)
                waypointCollection = new Cyclic(m_Waypoints.Count);
            else
                waypointCollection = new PingPong(m_Waypoints.Count);

            _currentPointIndex = waypointCollection.GetWaypointEnumerator();
            _currentPointIndex.MoveNext();
        }

        private void OnDestroy()
        {
            _tween.Stop(false);
        }
    }
}

using System.Collections.Generic;

namespace SAS.TweenManagement.Waypoints
{
    public class SinglePass : WaypointCollection
    {
        public SinglePass(int waypoints, int startIndex = 0) : base(waypoints, startIndex)
        {
        }

        public override IEnumerator<int> GetWaypointEnumerator()
        {
            if (_maxWaypoints < 2)
                yield break;

            var index = _startIndex;

            while (index < _maxWaypoints)
            {
                yield return index;
                ++index;
            }
        }
    }
}

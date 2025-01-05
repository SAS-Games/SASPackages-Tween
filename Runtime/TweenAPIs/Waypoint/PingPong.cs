using System.Collections.Generic;

namespace SAS.TweenManagement.Waypoints
{
    public class PingPong : WaypointCollection
    {
        public PingPong(int waypoints, int startIndex = 0) : base(waypoints, startIndex)
        {
        }

        public override IEnumerator<int> GetWaypointEnumerator()
        {
            if (_maxWaypoints < 2)
                yield break;
            var direction = 1;
            var index = _startIndex;

            while (true)
            {
                yield return index;

                if (index <= 0)
                    direction = 1;
                else if (index >= _maxWaypoints - 1)
                    direction = -1;

                index += direction;
            }
        }
    }
}

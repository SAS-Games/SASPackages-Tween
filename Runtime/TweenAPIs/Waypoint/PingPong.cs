using System.Collections.Generic;

namespace SAS.TweenManagement.Waypoints
{
    public class PingPong : WaypointCollection
    {
        public PingPong(int waypoints) : base(waypoints)
        {
        }

        public override IEnumerator<int> GetWaypointEnumerator()
        {
            if (_maxWaypoints < 2)
                yield break;
            var direction = 1;
            var index = 0;

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

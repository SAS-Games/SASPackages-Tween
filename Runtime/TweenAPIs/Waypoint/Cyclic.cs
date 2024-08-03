using System.Collections.Generic;

namespace SAS.TweenManagement.Waypoints
{
    public class Cyclic : WaypointCollection
    {
        public Cyclic(int waypoints) : base(waypoints)
        {
        }

        public override IEnumerator<int> GetWaypointEnumerator()
        {
            if (_maxWaypoints < 2)
                yield break;

            var index = 0;

            while (true)
            {
                yield return index;

                if (index == _maxWaypoints - 1)
                    index = -1;

                ++index;
            }
        }
    }
}

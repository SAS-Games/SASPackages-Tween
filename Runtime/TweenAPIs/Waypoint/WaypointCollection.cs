using System.Collections.Generic;

namespace SAS.TweenManagement.Waypoints
{
    interface IWaypointCollection
    {
        IEnumerator<int> GetWaypointEnumerator();
    }

    public abstract class WaypointCollection : IWaypointCollection
    {
        protected int _maxWaypoints;
        protected int _startIndex;

        public WaypointCollection(int maxWaypoints, int startIndex = 0)
        {
            _maxWaypoints = maxWaypoints;
            _startIndex = startIndex;
        }

        public abstract IEnumerator<int> GetWaypointEnumerator();
    }
}


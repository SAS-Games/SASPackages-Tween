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

        public WaypointCollection(int maxWaypoints)
        {
            _maxWaypoints = maxWaypoints;
        }

        public abstract IEnumerator<int> GetWaypointEnumerator();
    }
}


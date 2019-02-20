using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotWars.Battle
{
    public class Route : IEquatable<Route>
    {
        private readonly IEnumerable<RouteStep> _routeSteps;

        private Route(IEnumerable<RouteStep> routeSteps)
        {
            _routeSteps = routeSteps;
        }

        public bool Equals(Route other)
        {
            return (other != null &&
                    _routeSteps.SequenceEqual(other._routeSteps));
        }

        public static Route From(IEnumerable<RouteStep> routeSteps)
        {
            if(routeSteps == null)
                throw new ArgumentNullException("routeSteps", "Parameter must not be null");
            return new Route(routeSteps);
        }

        internal Position Apply(GridSize gridSize, Position position)
        {
            foreach (var routeStep in _routeSteps)
            {
                position = position.Apply(routeStep)
                                   .Check(gridSize);
                if (position.Equals(Position.Invalid))
                    throw new InvalidRouteException();
            }
            return position;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var routeStep in _routeSteps)
            {
                sb.Append(routeStep);
            }
            return sb.ToString();
        }
    }
}
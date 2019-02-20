using System;
using System.Text;

namespace RobotWars.Battle
{
    public class Robot : IEquatable<Robot>
    {
        private readonly Position _position;
        private readonly Route _route;

        private Robot(Position position, Route route)
        {
            _position = position;
            _route = route;
        }

        public bool Equals(Robot other)
        {
            return (other != null &&
                    _position.Equals(other._position) &&
                    _route.Equals(other._route));
        }

        public static Robot From(Position position, Route route)
        {
            return new Robot(position, route);
        }

        internal Position FollowRoute(GridSize gridSize)
        {
            return _route.Apply(gridSize, _position);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_position.ToString());
            sb.AppendLine(_route.ToString());
            return sb.ToString();
        }
    }
}
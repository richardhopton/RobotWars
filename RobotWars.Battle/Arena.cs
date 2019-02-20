using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotWars.Battle
{
    public class Arena : IEquatable<Arena>
    {
        private readonly GridSize _gridSize;
        private readonly IEnumerable<Robot> _robots;

        private Arena(GridSize gridSize, IEnumerable<Robot> robots)
        {
            _gridSize = gridSize;
            _robots = robots;
        }

        public bool Equals(Arena other)
        {
            return (other != null &&
                    _gridSize.Equals(other._gridSize) &&
                    _robots.SequenceEqual(other._robots));
        }

        public static Arena From(GridSize gridSize, IEnumerable<Robot> robots)
        {
            return new Arena(gridSize, robots);
        }

        public IEnumerable<Position> RunBattle()
        {
            return _robots
                .Select(robot => robot.FollowRoute(_gridSize))
                .ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_gridSize.ToString());
            foreach (var robot in _robots)
            {
                sb.AppendLine(robot.ToString()
                                   .TrimEnd());
            }
            return sb.ToString();
        }
    }
}
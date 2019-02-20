using System;

namespace RobotWars.Battle
{
    public class Position : IEquatable<Position>
    {
        public static Position Invalid { get { return new Position(-1, -1, CardinalCompassPoint.North()); } }

        private readonly int _xCoordinate;
        private readonly int _yCoordinate;
        private readonly CardinalCompassPoint _cardinalCompassPoint;
        private Position(Int32 xCoordinate, Int32 yCoordinate, CardinalCompassPoint cardinalCompassPoint)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
            _cardinalCompassPoint = cardinalCompassPoint;
        }

        public bool Equals(Position other)
        {
            return (other != null &&
                    _xCoordinate == other._xCoordinate &&
                    _yCoordinate == other._yCoordinate &&
                    _cardinalCompassPoint.Equals(other._cardinalCompassPoint));
        }

        public static Position From(Int32 xCoordinate, Int32 yCoordinate, CardinalCompassPoint cardinalCompassPoint)
        {
            return new Position(xCoordinate, yCoordinate, cardinalCompassPoint);
        }

        internal Position Apply(RouteStep routeStep)
        {
            return routeStep.Apply(_xCoordinate, _yCoordinate, _cardinalCompassPoint);
        }

        internal Position Check(GridSize gridSize)
        {
            if (_xCoordinate > -1 &&
                _yCoordinate > -1 &&
                gridSize.IsValid(_xCoordinate, _yCoordinate))
                return this;

            return Invalid;
        }

        public override string ToString()
        {
            return String.Join(" ", _xCoordinate, _yCoordinate, _cardinalCompassPoint);
        }
    }
}
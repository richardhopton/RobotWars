using System;

namespace RobotWars.Battle
{
    public class GridSize : IEquatable<GridSize>
    {
        private readonly int _width;
        private readonly int _height;

        private GridSize(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public bool Equals(GridSize other)
        {
            return (other != null &&
                    _width == other._width &&
                    _height == other._height);
        }

        public static GridSize From(int width, int height)
        {
            return new GridSize(width, height);
        }

        public Boolean IsValid(int xCoordinate, int yCoordinate)
        {
            return (xCoordinate <= _width &&
                    yCoordinate <= _height);
        }

        public override string ToString()
        {
            return String.Join(" ", _width, _height);
        }
    }
}
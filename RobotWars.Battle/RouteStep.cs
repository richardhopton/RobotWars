using System;

namespace RobotWars.Battle
{
    public abstract class RouteStep : IEquatable<RouteStep>
    {
        public virtual bool Equals(RouteStep other)
        {
            return other != null &&
                   GetType() == other.GetType();
        }

        public static RouteStep RotateLeft90Degrees()
        {
            return new RotateLeft90Degrees();
        }

        public static RouteStep RotateRight90Degrees()
        {
            return new RotateRight90Degrees();
        }

        public static RouteStep MoveOneGridSpace()
        {
            return new MoveOneGridSpace();
        }

        public static RouteStep MoveBackOneGridSpace()
        {
            return new MoveBackOneGridSpace();
        }

        protected internal abstract Position Apply(Int32 xCoordinate, Int32 yCoordinate, CardinalCompassPoint cardinalCompassPoint);
    }
}
using System;

namespace RobotWars.Battle
{
    public abstract class CardinalCompassPoint : IEquatable<CardinalCompassPoint>
    {
        public bool Equals(CardinalCompassPoint other)
        {
            return (other != null &&
                    GetType() == other.GetType());
        }

        public static CardinalCompassPoint North()
        {
            return new NorthCardinalCompassPoint();
        }

        public static CardinalCompassPoint East()
        {
            return new EastCardinalCompassPoint();
        }

        public static CardinalCompassPoint South()
        {
            return new SouthCardinalCompassPoint();
        }

        public static CardinalCompassPoint West()
        {
            return new WestCardinalCompassPoint();
        }

        protected internal abstract CardinalCompassPoint GetPreviousCardinalCompassPoint();
        protected internal abstract CardinalCompassPoint GetNextCardinalCompassPoint();

        internal int GetXDeltaWhenMoving(int offset)
        {
            return offset * GetXDelta();
        }

        internal Int32 GetYDeltaWhenMoving(Int32 offset)
        {
            return offset * GetYDelta();
        }

        protected virtual Int32 GetXDelta()
        {
            return 0;
        }

        protected virtual Int32 GetYDelta()
        {
            return 0;
        }
    }
}
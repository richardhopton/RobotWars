namespace RobotWars.Battle
{
    internal class WestCardinalCompassPoint : CardinalCompassPoint
    {
        protected internal override CardinalCompassPoint GetPreviousCardinalCompassPoint()
        {
            return South();
        }

        protected internal override CardinalCompassPoint GetNextCardinalCompassPoint()
        {
            return North();
        }

        protected override int GetXDelta()
        {
            return -1;
        }

        public override string ToString()
        {
            return "W";
        }
    }
}
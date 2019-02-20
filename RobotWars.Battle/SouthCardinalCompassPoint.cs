namespace RobotWars.Battle
{
    internal class SouthCardinalCompassPoint : CardinalCompassPoint
    {
        protected internal override CardinalCompassPoint GetPreviousCardinalCompassPoint()
        {
            return East();
        }

        protected internal override CardinalCompassPoint GetNextCardinalCompassPoint()
        {
            return West();
        }

        protected override int GetYDelta()
        {
            return -1;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}

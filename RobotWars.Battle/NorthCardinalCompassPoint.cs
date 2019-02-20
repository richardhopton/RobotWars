namespace RobotWars.Battle
{
    internal class NorthCardinalCompassPoint : CardinalCompassPoint
    {
        protected internal override CardinalCompassPoint GetPreviousCardinalCompassPoint()
        {
            return West();
        }

        protected internal override CardinalCompassPoint GetNextCardinalCompassPoint()
        {
            return East();
        }

        protected override int GetYDelta()
        {
            return 1;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
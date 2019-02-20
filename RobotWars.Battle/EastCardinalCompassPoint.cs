namespace RobotWars.Battle
{
    internal class EastCardinalCompassPoint : CardinalCompassPoint
    {
        protected internal override CardinalCompassPoint GetPreviousCardinalCompassPoint()
        {
            return North();
        }

        protected internal override CardinalCompassPoint GetNextCardinalCompassPoint()
        {
            return South();
        }

        protected override int GetXDelta()
        {
            return 1;
        }

        public override string ToString()
        {
            return "E";
        }
    }
}
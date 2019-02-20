namespace RobotWars.Battle
{
    internal class RotateRight90Degrees : RouteStep
    {
        protected internal override Position Apply(int xCoordinate, int yCoordinate, CardinalCompassPoint cardinalCompassPoint)
        {
            cardinalCompassPoint = cardinalCompassPoint.GetNextCardinalCompassPoint();
            return Position.From(xCoordinate, yCoordinate, cardinalCompassPoint);
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
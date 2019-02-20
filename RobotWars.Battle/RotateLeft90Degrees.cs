namespace RobotWars.Battle
{
    internal class RotateLeft90Degrees : RouteStep
    {
        protected internal override Position Apply(int xCoordinate, int yCoordinate, CardinalCompassPoint cardinalCompassPoint)
        {
            cardinalCompassPoint = cardinalCompassPoint.GetPreviousCardinalCompassPoint();
            return Position.From(xCoordinate, yCoordinate, cardinalCompassPoint);
        }

        public override string ToString()
        {
            return "L";
        }
    }
}
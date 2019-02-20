namespace RobotWars.Battle
{
    internal class MoveBackOneGridSpace : RouteStep
    {
        protected internal override Position Apply(int xCoordinate, int yCoordinate, CardinalCompassPoint cardinalCompassPoint)
        {
            xCoordinate += cardinalCompassPoint.GetXDeltaWhenMoving(-1);
            yCoordinate += cardinalCompassPoint.GetYDeltaWhenMoving(-1);
            return Position.From(xCoordinate, yCoordinate, cardinalCompassPoint);
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
using RobotWars.Battle;

namespace RobotWars.InputParser.Tests.Doubles
{
    public class DownRouteStep : RouteStep
    {
        protected override Position Apply(int xCoordinate, int yCoordinate, CardinalCompassPoint cardinalCompassPoint)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
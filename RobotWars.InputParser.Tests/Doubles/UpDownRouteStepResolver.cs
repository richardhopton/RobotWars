using RobotWars.Battle;
using RobotWars.InputParsers;

namespace RobotWars.InputParser.Tests.Doubles
{
    public class UpDownRouteStepResolver : IRouteStepResolver
    {
        public RouteStep Resolve(char input)
        {
            switch (input)
            {
                case 'U':
                    return new UpRouteStep();
                case 'D':
                    return new DownRouteStep();
            }
            return null;
        }
    }
}

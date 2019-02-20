using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class MoveBackOneGridSpaceRouteStepResolver : IRouteStepResolver
    {
        public RouteStep Resolve(char input)
        {
            return input == 'B' ? RouteStep.MoveBackOneGridSpace() : null;
        }
    }
}

using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class MoveOneGridSpaceRouteStepResolver : IRouteStepResolver
    {
        public RouteStep Resolve(char input)
        {
            return input == 'M' ? RouteStep.MoveOneGridSpace() : null;
        }
    }
}
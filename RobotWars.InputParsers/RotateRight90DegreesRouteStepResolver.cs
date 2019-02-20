using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class RotateRight90DegreesRouteStepResolver : IRouteStepResolver
    {
        public RouteStep Resolve(char input)
        {
            return input == 'R' ? RouteStep.RotateRight90Degrees() : null;
        }
    }
}
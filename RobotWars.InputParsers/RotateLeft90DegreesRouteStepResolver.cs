using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class RotateLeft90DegreesRouteStepResolver : IRouteStepResolver
    {
        public RouteStep Resolve(char input)
        {
            return input == 'L' ? RouteStep.RotateLeft90Degrees() : null;
        }
    }
}
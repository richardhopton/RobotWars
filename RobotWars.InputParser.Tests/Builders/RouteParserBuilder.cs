using System.Linq;
using RobotWars.InputParsers;

namespace RobotWars.InputParser.Tests.Builders
{
    public static class RouteParserBuilder
    {
        public static IRouteParser Build(params IRouteStepResolver[] resolvers)
        {
            if (!resolvers.Any())
            {
                resolvers = new IRouteStepResolver[]
                {
                    new MoveBackOneGridSpaceRouteStepResolver(),
                    new RotateLeft90DegreesRouteStepResolver(),
                    new RotateRight90DegreesRouteStepResolver(),
                    new MoveOneGridSpaceRouteStepResolver()
                };
            }
            return new RouteParser(resolvers);
        }
    }
}

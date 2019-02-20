using RobotWars.InputParsers;

namespace RobotWars.InputParser.Tests.Builders
{
    public static class RobotParserBuilder
    {
        public static IRobotParser Build()
        {
            var positionParser = PositionParserBuilder.Build();
            var routeParser = RouteParserBuilder.Build();
            return new RobotParser(positionParser, routeParser);
        }
    }
}
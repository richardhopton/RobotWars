using RobotWars.InputParsers;

namespace RobotWars.InputParser.Tests.Builders
{
    public static class PositionParserBuilder
    {
        public static IPositionParser Build()
        {
            var resolvers = new ICardinalCompassPointResolver[]
            {
                new NorthCardinalCompassPointResolver(),
                new EastCardinalCompassPointResolver(),
                new SouthCardinalCompassPointResolver(),
                new WestCardinalCompassPointResolver()
            };
            return new PositionParser(resolvers);
        }
    }
}
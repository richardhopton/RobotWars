using RobotWars.InputParsers;

namespace RobotWars.InputParser.Tests.Builders
{
    public static class GridSizeParserBuilder
    {
        public static IGridSizeParser Build()
        {
            return new GridSizeParser();
        }
    }
}
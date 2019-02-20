using RobotWars.InputParsers;

namespace RobotWars.InputParser.Tests.Builders
{
    public static class ArenaParserBuilder
    {
        public static IArenaParser Build()
        {
            var gridSizeParser = GridSizeParserBuilder.Build();
            var robotParser = RobotParserBuilder.Build();
            return new ArenaParser(gridSizeParser, robotParser);
        }
    }
}
using System;
using System.Linq;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class ArenaParser : IArenaParser
    {
        private readonly IGridSizeParser _gridSizeParser;
        private readonly IRobotParser _robotParser;

        public ArenaParser(IGridSizeParser gridSizeParser, IRobotParser robotParser)
        {
            _gridSizeParser = gridSizeParser;
            _robotParser = robotParser;
        }

        public Arena Parse(string[] input)
        {
            if (input == null)
                throw new ArgumentNullException("input", "Parameter cannot be null");
            if (input.Length < 3)
                throw new TooFewLinesException("Parameter contains too few lines, expect 3 or more lines");
            if (input.Length % 2 == 0)
                throw new TooFewLinesException("Parameter contains too few lines, require odd number of lines");

            var enumerator = input.AsEnumerable()
                                  .GetEnumerator();
            enumerator.MoveNext();
            var gridSize = _gridSizeParser.Parse(enumerator.Current);

            var robotCount = (input.Length - 1) / 2;
            var robots = new Robot[robotCount];
            var index = 0;
            while (enumerator.MoveNext())
            {
                var robot = _robotParser.Parse(enumerator);
                robots[index] = robot;
                index++;
            }
            return Arena.From(gridSize, robots);
        }
    }
}
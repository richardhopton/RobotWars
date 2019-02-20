using System;
using RobotWars.Battle;
using RobotWars.InputParsers;

namespace RobotWars.Tests.Doubles
{
    public class InputCapturingArenaParser : IArenaParser
    {
        public String[] Input { get; private set; }
        public Arena Parse(string[] input)
        {
            Input = input;
            return Arena.From(GridSize.From(5, 5),
                              new[]
                              {
                                  Robot.From(Position.From(0, 0, CardinalCompassPoint.North()),
                                             Route.From(new[]
                                             {
                                                 RouteStep.RotateRight90Degrees(),
                                                 RouteStep.MoveOneGridSpace(),
                                                 RouteStep.RotateLeft90Degrees()
                                             }))
                              }
                );
        }
    }
}

using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_arena_from_input_with_multiple_robots : ContextSpecification
    {
        private string[] _lines;
        private IArenaParser _arenaParser;
        private Arena _arena;
        private Exception _exception;

        protected override void Establish()
        {
            _lines = new[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM",
                "1 2 S",
                "LMLMLMLMM",
                "3 3 W",
                "MMRMMRMRRM"
            };
            _arenaParser = ArenaParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _arena = _arenaParser.Parse(_lines));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.Null);
        }

        [Test]
        public void should_set_arena()
        {
            Assert.That(_arena, Is.Not.Null);
        }

        [Test]
        public void should_have_correct_gridsize_and_robots()
        {
            var expected = Arena.From
                (GridSize.From(5, 5),
                 new[]
                 {
                     Robot.From
                     (Position.From(1, 2, CardinalCompassPoint.North()),
                      Route.From(new[]
                      {
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.MoveOneGridSpace()
                      })),
                     Robot.From
                     (Position.From(3, 3, CardinalCompassPoint.East()),
                      Route.From(new[]
                      {
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace()
                      })),
                      Robot.From
                     (Position.From(1, 2, CardinalCompassPoint.South()),
                      Route.From(new[]
                      {
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.MoveOneGridSpace()
                      })),
                     Robot.From
                     (Position.From(3, 3, CardinalCompassPoint.West()),
                      Route.From(new[]
                      {
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace()
                      }))
                 });

            Assert.That(_arena, Is.EqualTo(expected));
        }

        [Test]
        public void should_have_correct_text_representation()
        {
            var lines = _arena.ToString()
                              .TrimEnd()
                              .Split(new[] {"\r\n"}, StringSplitOptions.None);
            Assert.That(_lines, Is.EquivalentTo(lines));
        }
    }
}

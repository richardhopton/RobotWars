using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_arena_from_input_with_one_robot : ContextSpecification
    {
        private string[] _lines;
        private IArenaParser _arenaParser;
        private Arena _arena;
        private Exception _exception;

        protected override void Establish()
        {
            _lines = new[] {"5 6", "0 1 N", "RMLMRMLM"};
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
                (GridSize.From(5, 6),
                 new[]
                 {
                     Robot.From
                     (Position.From(0, 1, CardinalCompassPoint.North()),
                      Route.From(new[]
                      {
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateRight90Degrees(),
                          RouteStep.MoveOneGridSpace(),
                          RouteStep.RotateLeft90Degrees(),
                          RouteStep.MoveOneGridSpace()
                      }))
                 });

            Assert.That(_arena, Is.EqualTo(expected));
        }
    }
}

using System;
using System.Collections.Generic;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.Tests
{
    public class when_running_battle_from_arena_with_two_robots : ContextSpecification
    {
        private string[] _lines;
        private Arena _arena;
        private IEnumerable<Position> _finalRobotPositions;
        private Exception _exception;

        protected override void Establish()
        {
            _lines = new[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
            var container = ContainerFactory.Create();
            _arena = container.Resolve<IArenaParser>().Parse(_lines);
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _finalRobotPositions = _arena.RunBattle());
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.Null);
        }

        [Test]
        public void should_set_finalrobotpositions()
        {
            Assert.That(_finalRobotPositions, Is.Not.Null);
        }

        [Test]
        public void should_have_correct_positions()
        {
            var expected = new[]
            {
                Position.From(1, 3, CardinalCompassPoint.North()),
                Position.From(5, 1, CardinalCompassPoint.East())
            };

            Assert.That(_finalRobotPositions, Is.EqualTo(expected));
        }
    }
}

using System;
using System.Collections.Generic;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.Tests
{
    public class when_running_battle_from_arena_with_two_robots_new_tests : ContextSpecification
    {
        private string[] _lines;
        private Arena _arena;
        private IEnumerable<Position> _finalRobotPositions;
        private Exception _exception;

        protected override void Establish()
        {
            _lines = new[]
            {
                "5 6",
                "0 0 E",
                "MMLMMLMMRBB",
                "4 5 W",
                "BLBLBLBL"
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
                Position.From(0, 0, CardinalCompassPoint.North()),
                Position.From(4, 5, CardinalCompassPoint.West())
            };

            Assert.That(_finalRobotPositions, Is.EqualTo(expected));
        }
    }
}

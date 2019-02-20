using System;
using System.Collections.Generic;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.Tests
{
    public class when_running_battle_from_arena_with_invalid_route : ContextSpecification
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
                "0 0 N",
                "LMLMLMLMM"
            };
            var container = ContainerFactory.Create();
            _arena = container.Resolve<IArenaParser>().Parse(_lines);
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _finalRobotPositions = _arena.RunBattle());
        }

        [Test]
        public void should_throw_an_invalidrouteexception()
        {
            Assert.That(_exception, Is.TypeOf<InvalidRouteException>());
        }

        [Test]
        public void should_not_set_finalrobotpositions()
        {
            Assert.That(_finalRobotPositions, Is.Null);
        }
    }
}

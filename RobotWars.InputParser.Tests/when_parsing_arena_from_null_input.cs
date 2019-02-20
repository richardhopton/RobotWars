using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_arena_from_null_input : ContextSpecification
    {
        private string[] _lines;
        private IArenaParser _arenaParser;
        private Arena _arena;
        private Exception _exception;

        protected override void Establish()
        {
            _lines = null;
            _arenaParser = ArenaParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _arena = _arenaParser.Parse(_lines));
        }

        [Test]
        public void should_throw_an_argumentnullexception()
        {
            Assert.That(_exception, Is.TypeOf<ArgumentNullException>());
        }
        
        [Test]
        public void should_not_set_arena()
        {
            Assert.That(_arena, Is.Null);
        }
    }
}

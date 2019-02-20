using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_arena_from_input_with_incorrect_number_of_lines : ContextSpecification
    {
        private string[] _lines;
        private IArenaParser _arenaParser;
        private Arena _arena;
        private Exception _exception;

        protected override void Establish()
        {
            _lines = new[] {"5 5", "0 0 N", "RMLM", "0 1 W"};
            _arenaParser = ArenaParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _arena = _arenaParser.Parse(_lines));
        }

        [Test]
        public void should_throw_a_toofewlinesexception()
        {
            Assert.That(_exception, Is.TypeOf<TooFewLinesException>());
        }
        
        [Test]
        public void should_not_set_arena()
        {
            Assert.That(_arena, Is.Null);
        }
    }
}

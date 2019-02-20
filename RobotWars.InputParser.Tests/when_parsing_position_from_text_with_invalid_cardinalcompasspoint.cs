using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_position_from_text_with_invalid_cardinalcompasspoint : ContextSpecification
    {
        private Exception _exception;
        private String _positionText;
        private Position _position;
        private IPositionParser _positionParser;

        protected override void Establish()
        {
            _positionText = "5 5 XY";
            _positionParser = PositionParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _position = _positionParser.Parse(_positionText));
        }

        [Test]
        public void should_throw_an_argumentoutofrangeexception()
        {
            Assert.That(_exception, Is.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void should_not_set_position()
        {
            Assert.That(_position, Is.Null);
        }
    }
}
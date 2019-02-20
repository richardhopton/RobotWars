using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_position_from_text_with_unknown_cardinalcompasspoint : ContextSpecification
    {
        private Exception _exception;
        private String _positionText;
        private Position _position;
        private IPositionParser _positionParser;

        protected override void Establish()
        {
            _positionText = "5 5 X";
            _positionParser = PositionParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _position = _positionParser.Parse(_positionText));
        }

        [Test]
        public void should_throw_an_unabletoresolvecardinalcompasspointexception()
        {
            Assert.That(_exception, Is.TypeOf<UnableToResolveCardinalCompassPointException>());
            var exception = (UnableToResolveCardinalCompassPointException)_exception;
            Assert.That(exception.Value, Is.EqualTo('X'));
        }

        [Test]
        public void should_not_set_position()
        {
            Assert.That(_position, Is.Null);
        }
    }
}
using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_position_from_text : ContextSpecification
    {
        private Exception _exception;
        private String _positionText;
        private Position _position;
        private IPositionParser _positionParser;

        protected override void Establish()
        {
            _positionText = "5 6 N";
            _positionParser = PositionParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _position = _positionParser.Parse(_positionText));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.Null);
        }

        [Test]
        public void should_set_position()
        {
            Assert.That(_position, Is.Not.Null);
        }

        [Test]
        public void should_have_correct_coordinates_and_cardinalcompasspoint()
        {
            var expected = Position.From(5, 6, CardinalCompassPoint.North());
            Assert.That(_position, Is.EqualTo(expected));
        }
    }
}

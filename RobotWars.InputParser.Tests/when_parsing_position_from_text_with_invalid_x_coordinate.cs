using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_position_from_text_with_invalid_x_coordinate : ContextSpecification
    {
        private Exception _exception;
        private String _positionText;
        private Position _position;
        private IPositionParser _positionParser;

        protected override void Establish()
        {
            _positionText = "z 5 N";
            _positionParser = PositionParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _position = _positionParser.Parse(_positionText));
        }

        [Test]
        public void should_throw_an_invalidxcoordinateexception()
        {
            Assert.That(_exception, Is.TypeOf<InvalidXCoordinateException>());
            var exception = (InvalidXCoordinateException)_exception;
            Assert.That(exception.Value, Is.EqualTo("z"));
        }

        [Test]
        public void should_not_set_position()
        {
            Assert.That(_position, Is.Null);
        }
    }
}
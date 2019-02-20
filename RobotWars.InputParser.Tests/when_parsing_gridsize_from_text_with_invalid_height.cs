using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_gridsize_from_text_with_invalid_height : ContextSpecification
    {
        private Exception _exception;
        private String _gridSizeText;
        private GridSize _gridSize;
        private IGridSizeParser _gridSizeParser;

        protected override void Establish()
        {
            _gridSizeText = "5 z";
            _gridSizeParser = GridSizeParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _gridSize = _gridSizeParser.Parse(_gridSizeText));
        }

        [Test]
        public void should_throw_an_invalidheightexception()
        {
            Assert.That(_exception, Is.TypeOf<InvalidHeightException>());
            var exception = (InvalidHeightException)_exception;
            Assert.That(exception.Value, Is.EqualTo("z"));
        }

        [Test]
        public void should_not_set_gridsize()
        {
            Assert.That(_gridSize, Is.Null);
        }
    }
}
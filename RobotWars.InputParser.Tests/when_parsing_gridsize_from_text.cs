using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_gridsize_from_text : ContextSpecification
    {
        private Exception _exception;
        private String _gridSizeText;
        private GridSize _gridSize;
        private IGridSizeParser _gridSizeParser;

        protected override void Establish()
        {
            _gridSizeText = "5 6";
            _gridSizeParser = GridSizeParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _gridSize = _gridSizeParser.Parse(_gridSizeText));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.Null);
        }

        [Test]
        public void should_set_gridsize()
        {
            Assert.That(_gridSize, Is.Not.Null);
        }

        [Test]
        public void should_have_correct_dimensions()
        {
            var expected = GridSize.From(5, 6);
            Assert.That(_gridSize, Is.EqualTo(expected));
        }
    }
}

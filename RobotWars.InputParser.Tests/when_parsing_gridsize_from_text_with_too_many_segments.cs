using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_gridsize_from_text_with_too_many_segments : ContextSpecification
    {
        private Exception _exception;
        private String _gridSizeText;
        private GridSize _gridSize;
        private IGridSizeParser _gridSizeParser;

        protected override void Establish()
        {
            _gridSizeText = "5 X 5";
            _gridSizeParser = GridSizeParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _gridSize = _gridSizeParser.Parse(_gridSizeText));
        }

        [Test]
        public void should_throw_a_toomanysegmentsexception()
        {
            Assert.That(_exception, Is.TypeOf<TooManySegmentsException>());
        }

        [Test]
        public void should_not_set_gridsize()
        {
            Assert.That(_gridSize, Is.Null);
        }
    }
}
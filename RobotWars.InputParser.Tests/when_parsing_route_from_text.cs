using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_route_from_text : ContextSpecification
    {
        private Exception _exception;
        private String _routeText;
        private Route _route;
        private IRouteParser _routeParser;

        protected override void Establish()
        {
            _routeText = "LRMRLMMRMLM";
            _routeParser = RouteParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _route = _routeParser.Parse(_routeText));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.Null);
        }

        [Test]
        public void should_set_route()
        {
            Assert.That(_route, Is.Not.Null);
        }

        [Test]
        public void should_have_correct_steps()
        {
            var expected = new[]
            {
                RouteStep.RotateLeft90Degrees(),
                RouteStep.RotateRight90Degrees(),
                RouteStep.MoveOneGridSpace(), 
                RouteStep.RotateRight90Degrees(),
                RouteStep.RotateLeft90Degrees(),
                RouteStep.MoveOneGridSpace(), 
                RouteStep.MoveOneGridSpace(), 
                RouteStep.RotateRight90Degrees(),
                RouteStep.MoveOneGridSpace(), 
                RouteStep.RotateLeft90Degrees(),
                RouteStep.MoveOneGridSpace()
            };
            var route = Route.From(expected);
            Assert.That(_route, Is.EqualTo(route));
        }
    }
}

using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParser.Tests.Doubles;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_route_with_custom_routestepresolver : ContextSpecification
    {
        private Exception _exception;
        private String _routeText;
        private Route _route;
        private IRouteParser _routeParser;

        protected override void Establish()
        {
            _routeText = "UDM";
            _routeParser = RouteParserBuilder.Build(new UpDownRouteStepResolver(), new MoveOneGridSpaceRouteStepResolver());
            _route = null;
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
                new UpRouteStep(),
                new DownRouteStep(),
                RouteStep.MoveOneGridSpace()
            };
            var route = Route.From(expected);
            Assert.That(_route, Is.EqualTo(route));
        }

        [Test]
        public void should_have_correct_text()
        {
            var routeText = _route.ToString();
            Assert.That(_routeText, Is.EqualTo(routeText));
        }
    }
}
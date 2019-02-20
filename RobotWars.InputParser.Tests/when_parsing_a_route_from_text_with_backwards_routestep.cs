using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_a_route_from_text_with_backwards_routestep : ContextSpecification
    {
        private Exception _exception;
        private String _routeText;
        private Route _route;
        private IRouteParser _routeParser;

        protected override void Establish()
        {
            _routeText = "MMLMMLMMRBB";
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
        public void should_have_string_representation_that_matches_route_text()
        {
            var routeText = _route.ToString();
            Assert.That(routeText, Is.EqualTo(_routeText));
        }
    }
}
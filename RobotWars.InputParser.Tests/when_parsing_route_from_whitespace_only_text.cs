using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_route_from_whitespace_only_text : ContextSpecification
    {
        private Exception _exception;
        private String _routeText;
        private Route _route;
        private IRouteParser _routeParser;

        protected override void Establish()
        {
            _routeText = "    \t   \r\n   ";
            _routeParser = RouteParserBuilder.Build();
            _route = null;
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _route = _routeParser.Parse(_routeText));
        }

        [Test]
        public void should_throw_an_argumentexception()
        {
            Assert.That(_exception, Is.TypeOf<ArgumentException>());
        }

        [Test]
        public void should_not_set_route()
        {
            Assert.That(_route, Is.Null);
        }
    }
}
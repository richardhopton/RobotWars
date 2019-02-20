using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.InputParser.Tests.Builders;
using RobotWars.InputParsers;
using RobotWars.Tests.Helpers;

namespace RobotWars.InputParser.Tests
{
    public class when_parsing_route_from_text_with_unknown_routestep : ContextSpecification
    {
        private Exception _exception;
        private String _routeText;
        private Route _route;
        private IRouteParser _routeParser;

        protected override void Establish()
        {
            _routeText = "XYZABC123";
            _routeParser = RouteParserBuilder.Build();
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _route = _routeParser.Parse(_routeText));
        }

        [Test]
        public void should_throw_an_unabletoresolveroutestepexception()
        {
            Assert.That(_exception, Is.TypeOf<UnableToResolveRouteStepException>());
            var exception = (UnableToResolveRouteStepException)_exception;    
            Assert.That(exception.Value, Is.EqualTo('X'));
        }

        [Test]
        public void should_not_set_route()
        {
            Assert.That(_route, Is.Null);
        }
    }
}
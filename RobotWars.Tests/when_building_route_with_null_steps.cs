using System;
using NUnit.Framework;
using RobotWars.Battle;
using RobotWars.Tests.Helpers;

namespace RobotWars.Tests
{
    public class when_building_route_with_null_steps : ContextSpecification
    {
        private Exception _exception;
        private Route _route;

        protected override void Establish()
        {
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() => _route = Route.From(null));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void should_not_set_route()
        {
            Assert.That(_route, Is.Null);
        }
    }
}
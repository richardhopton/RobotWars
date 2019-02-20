using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class RouteParser : IRouteParser
    {
        private readonly IEnumerable<IRouteStepResolver> _routeStepResolvers;

        public RouteParser(IEnumerable<IRouteStepResolver> routeStepResolvers)
        {
            _routeStepResolvers = routeStepResolvers;
        }

        public Route Parse(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Parameter cannot be empty or whitespace", "text");

            var routeSteps = text.ToCharArray()
                                 .Select(Resolve)
                                 .ToArray();
            return Route.From(routeSteps);
        }

        private RouteStep Resolve(Char input)
        {
            var routeStep = _routeStepResolvers
                .Select(rsr => rsr.Resolve(input))
                .FirstOrDefault(rs => rs != null);

            if (routeStep == null)
                throw new UnableToResolveRouteStepException(input);

            return routeStep;
        }
    }
}
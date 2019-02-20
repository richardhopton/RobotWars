using System.Collections.Generic;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class RobotParser : IRobotParser
    {
        private readonly IPositionParser _positionParser;
        private readonly IRouteParser _routeParser;

        public RobotParser(IPositionParser positionParser, IRouteParser routeParser)
        {
            _positionParser = positionParser;
            _routeParser = routeParser;
        }

        public Robot Parse(IEnumerator<string> enumerator)
        {
            var position = _positionParser.Parse(enumerator.Current);
            enumerator.MoveNext();
            var route = _routeParser.Parse(enumerator.Current);
            return Robot.From(position, route);
        }
    }
}
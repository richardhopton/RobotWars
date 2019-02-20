using System;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface IRouteStepResolver
    {
        RouteStep Resolve(Char input);
    }
}
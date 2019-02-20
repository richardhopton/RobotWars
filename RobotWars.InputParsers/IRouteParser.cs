using System;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface IRouteParser
    {
        Route Parse(String text);
    }
}
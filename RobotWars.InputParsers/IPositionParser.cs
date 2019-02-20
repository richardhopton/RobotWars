using System;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface IPositionParser
    {
        Position Parse(String text);
    }
}
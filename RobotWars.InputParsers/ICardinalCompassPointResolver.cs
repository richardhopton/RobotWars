using System;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface ICardinalCompassPointResolver
    {
        CardinalCompassPoint Resolve(Char input);
    }
}
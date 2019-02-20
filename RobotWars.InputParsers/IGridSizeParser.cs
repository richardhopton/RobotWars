using System;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface IGridSizeParser
    {
        GridSize Parse(String text);
    }
}
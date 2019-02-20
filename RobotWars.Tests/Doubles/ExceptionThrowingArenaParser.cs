using System;
using RobotWars.Battle;
using RobotWars.InputParsers;

namespace RobotWars.Tests.Doubles
{
    public class ExceptionThrowingArenaParser : IArenaParser
    {
        public Arena Parse(string[] input)
        {
            throw new Exception("Exception thrown by ExceptionThrowingArenaParser");
        }
    }
}
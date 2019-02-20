using System;
using System.Collections.Generic;
using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface IRobotParser
    {
        Robot Parse(IEnumerator<String> enumerator);
    }
}
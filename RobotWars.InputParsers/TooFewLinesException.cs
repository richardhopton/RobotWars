using System;

namespace RobotWars.InputParsers
{
    public class TooFewLinesException : Exception
    {
        public TooFewLinesException(string message = "Too few lines")
            : base(message)
        {
        }
    }
}
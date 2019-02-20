using System;

namespace RobotWars.InputParsers
{
    public class TooManySegmentsException : Exception
    {
        public TooManySegmentsException(string message = "Too many segments")
            : base(message)
        {
        }
    }
}
using System;

namespace RobotWars.InputParsers
{
    public class TooFewSegmentsException : Exception
    {
        public TooFewSegmentsException(string message = "Too few segments")
            : base(message)
        {
        }
    }
}
using System;

namespace RobotWars.InputParsers
{
    public class UnableToResolveCardinalCompassPointException : Exception
    {
        private readonly char _value;
        
        public UnableToResolveCardinalCompassPointException(char value, string message = "Unable to resolve cardinal compass point")
            : base(message)
        {
            _value = value;
        }

        public char Value
        {
            get { return _value; }
        }
    }
}
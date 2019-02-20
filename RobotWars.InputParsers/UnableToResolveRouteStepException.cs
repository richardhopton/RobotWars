using System;

namespace RobotWars.InputParsers
{
    public class UnableToResolveRouteStepException : Exception
    {
        private readonly char _value;
        
        public UnableToResolveRouteStepException(char value, String message = "Unable to resolve route step")
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
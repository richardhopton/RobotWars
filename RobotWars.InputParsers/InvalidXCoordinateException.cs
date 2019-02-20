using System;

namespace RobotWars.InputParsers
{
    public class InvalidXCoordinateException : Exception
    {
        private readonly string _value;
        
        public InvalidXCoordinateException(string value, string message = "Invalid X coordinate")
            : base(message)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
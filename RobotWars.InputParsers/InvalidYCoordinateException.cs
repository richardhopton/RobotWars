using System;

namespace RobotWars.InputParsers
{
    public class InvalidYCoordinateException : Exception
    {
        private readonly string _value;
        
        public InvalidYCoordinateException(string value, string message = "Invalid Y coordinate")
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
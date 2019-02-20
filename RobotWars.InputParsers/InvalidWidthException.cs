using System;

namespace RobotWars.InputParsers
{
    public class InvalidWidthException : Exception
    {
        private readonly string _value;

        public InvalidWidthException(string value, String message = "Invalid Width")
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
using System;

namespace RobotWars.InputParsers
{
    public class InvalidHeightException : Exception
    {
        private readonly string _value;

        public InvalidHeightException(string value, string message = "Invalid height")
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
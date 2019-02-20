using System;

namespace RobotWars.Battle
{
    public class InvalidRouteException : Exception
    {
        public InvalidRouteException(string message = "Invalid route")
            : base(message)
        {
        }
    }
}
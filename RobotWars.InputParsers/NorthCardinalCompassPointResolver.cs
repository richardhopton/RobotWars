using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class NorthCardinalCompassPointResolver : ICardinalCompassPointResolver
    {
        public CardinalCompassPoint Resolve(char input)
        {
            return input == 'N' ? CardinalCompassPoint.North() : null;
        }
    }
}
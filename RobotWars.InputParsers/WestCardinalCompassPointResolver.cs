using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class WestCardinalCompassPointResolver : ICardinalCompassPointResolver
    {
        public CardinalCompassPoint Resolve(char input)
        {
            return input == 'W' ? CardinalCompassPoint.West() : null;
        }
    }
}
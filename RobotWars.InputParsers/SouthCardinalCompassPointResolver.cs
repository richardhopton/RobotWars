using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class SouthCardinalCompassPointResolver : ICardinalCompassPointResolver
    {
        public CardinalCompassPoint Resolve(char input)
        {
            return input == 'S' ? CardinalCompassPoint.South() : null;
        }
    }
}
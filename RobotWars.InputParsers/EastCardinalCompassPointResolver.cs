using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public class EastCardinalCompassPointResolver : ICardinalCompassPointResolver
    {
        public CardinalCompassPoint Resolve(char input)
        {
            return input == 'E' ? CardinalCompassPoint.East() : null;
        }
    }
}
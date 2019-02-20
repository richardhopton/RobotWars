using RobotWars.Battle;

namespace RobotWars.InputParsers
{
    public interface IArenaParser
    {
        Arena Parse(string[] input);
    }
}
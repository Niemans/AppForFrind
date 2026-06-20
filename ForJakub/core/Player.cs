using ForJakub.core.interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ForJakub.core
{
    internal class Player
        (ulong playerID, string playerName, double playerCurrentPoints)
        : IData
    {
        private const int c_relevantDecimalPoint = 5;

        public ulong PlayerID { get; init; } = playerID;
        public string PlayerName { get; init; } = playerName;
        public double PlayerCurrentPoints { get; set; } = playerCurrentPoints;

        private Game? LastGame { get; set; } = null;

        public double GetRoundedPoints()
        {
            return Math.Round(PlayerCurrentPoints, c_relevantDecimalPoint);
        }
    }
}

using ForJakub.core.interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ForJakub.core
{
    [method: SetsRequiredMembers]
    internal class Player() : IData
    {
        public const int relevantDecimalPoint = 5;

        public required ulong PlayerID { get; init; } = 0;
        public required string PlayerName { get; init; } = "";
        public required double PlayerCurrentPoints { get; set; } = 0;

        private Game? LastGame { get; set; }

        public double GetRoundedPoints()
        {
            return Math.Round(PlayerCurrentPoints, relevantDecimalPoint);
        }
    }
}

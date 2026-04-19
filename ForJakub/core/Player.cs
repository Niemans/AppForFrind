using ForJakub.core.interdaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core
{
    internal class Player : IData
    {
        public const int relevantDecimalPoint = 5;

        public required ulong PlayerID { get; init; }
        public required string PlayerName { get; init; }
        public required double PlayerCurrentPoints { get; set; }
        
        private Game? LastGame { get; set; }

        public double GetRoundedPoints()
        {
            return Math.Round(PlayerCurrentPoints, relevantDecimalPoint);
        }
    }
}

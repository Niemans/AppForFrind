using ForJakub.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core
{
    internal class Person
    {
        public const int relevantDecimalPoint = 5;

        public required int ID { get; init; }
        public required string Name { get; init; }
        public required double CurentPoints { get; set; }
        private long? LastGameID { get; set; }


        public double GetRoundedPoints()
        {
            return Math.Round(CurentPoints, relevantDecimalPoint);
        }
    }
}

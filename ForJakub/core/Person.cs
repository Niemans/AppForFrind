using ForJakub.core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core
{
    internal class Person : IPerson
    {
        public static int relevantDecimalPoint = 5;

        public required int ID { get; init; }
        public required string Name { get; init; }
        public required double Points { get; set; }



        public double GetRoundedPoints()
        {
            return Math.Round(Points, relevantDecimalPoint);
        }
    }
}

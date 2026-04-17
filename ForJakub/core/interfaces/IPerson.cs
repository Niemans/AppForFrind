using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ForJakub.core.interfaces
{
    internal interface IPerson
    {
        public int ID { init; get; }
        public string Name { init;  get; }
        public double Points { set; get; }


        public double GetRoundedPoints();
    }
}

using ForJakub.core.interdaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core
{
    internal class Entry : IData
    {
        public required Player Player { get; set; }
        public double PointsGain { get; set; }
        public int PlayerPlacement { get; set; }
    }
}
using ForJakub.core.interfaces;

namespace ForJakub.core
{
    internal class Entry : IData
    {
        public required Player Player { get; set; }
        public double PointsGain { get; set; }
        public int PlayerPlacement { get; set; }
    }
}
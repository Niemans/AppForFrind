using ForJakub.core.interfaces;

namespace ForJakub.core
{
    internal class Entry
        (Player player, double pointsGain, int playerPlacement) 
        : IData
    {
        public Player Player { get; set; } = player;
        public double PointsGain { get; set; } = pointsGain;
        public int PlayerPlacement { get; set; } = playerPlacement;
    }
}
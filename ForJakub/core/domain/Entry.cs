using ForJakub.core.interfaces;

namespace ForJakub.core.domain;

internal record Entry
    (Player Player, double PointsGain, int PlayerPlacement) 
    : IData
{
    public Player Player { get; set; } = Player;
    public double PointsGain { get; set; } = PointsGain;
    public int PlayerPlacement { get; set; } = PlayerPlacement;
}
using ForJakub.core.interfaces;

namespace ForJakub.core.domain;

internal record Player
    (ulong PlayerID, string PlayerName, double PlayerCurrentPoints)
    : IData
{
    private const int c_relevantDecimalPoint = 5;

    public ulong PlayerID { get; set; } = PlayerID;
    public string PlayerName { get; set; } = PlayerName;
    public double PlayerCurrentPoints { get; set; } = PlayerCurrentPoints;

    private Game? LastGame { get; set; } = null;

    public double GetRoundedPoints()
    {
        return Math.Round(PlayerCurrentPoints, c_relevantDecimalPoint);
    }
}
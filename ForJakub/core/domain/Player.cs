using ForJakub.core.interfaces;

namespace ForJakub.core.domain;

internal readonly record struct Player
    (ulong PlayerID, string PlayerName, double PlayerCurrentPoints)
    : IData
{
    private const int c_relevantDecimalPoint = 5;

    public double GetRoundedPoints()
    {
        return Math.Round(PlayerCurrentPoints, c_relevantDecimalPoint);
    }
}
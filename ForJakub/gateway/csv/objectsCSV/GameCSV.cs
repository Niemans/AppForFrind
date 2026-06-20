using ForJakub.core;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.objectsCSV;

internal class GameCSV(Game game, int entryIndex) : IDataCSV<Game>
{

    public ulong GameID { get; } = game.GameID;
    public DateTime Time { get; } = game.Time;
    public string Comment { get; } = game.Comment;
    public double PointsGain { get; } = game.playerEntries[entryIndex].PointsGain;
    public int PlayerPlacement { get; } = game.playerEntries[entryIndex].PlayerPlacement;
    public ulong PlayerID { get; } = game.playerEntries[entryIndex].Player.PlayerID;
    public string PlayerName { get; } = game.playerEntries[entryIndex].Player.PlayerName;
    public double PlayerCurrentPoints { get; } = game.playerEntries[entryIndex].Player.PlayerCurrentPoints;
}
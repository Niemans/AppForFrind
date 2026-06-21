using ForJakub.core;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.objectsCSV;

internal class GameCSV : IDataCSV<Game>
{
    public ulong GameID { get; set; }
    public DateTime Time { get; set; }
    public string Comment { get; set; }
    
    public double PointsGain { get; set; }
    public int PlayerPlacement { get; set; }
    public ulong PlayerID { get; set; }
    public string PlayerName { get; set; }
    public double PlayerCurrentPoints { get; set; }
    
    
    public GameCSV()
    {
        GameID = 0;
        Time = new DateTime();
        Comment = "";
        PlayerID = 0;
        PlayerName = "";
        PlayerCurrentPoints = 0;
        PlayerPlacement = 0;
        PointsGain = 0;

    }
    
    public GameCSV(Game game, int entryIndex)
    {
        GameID = game.GameID;
        Time = game.Time;
        Comment = game.Comment;
        PointsGain = game.playerEntries[entryIndex].PointsGain;
        PlayerPlacement = game.playerEntries[entryIndex].PlayerPlacement;
        PlayerID = game.playerEntries[entryIndex].Player.PlayerID;
        PlayerName = game.playerEntries[entryIndex].Player.PlayerName;
        PlayerCurrentPoints = game.playerEntries[entryIndex].Player.PlayerCurrentPoints;
    }

}
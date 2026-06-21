using ForJakub.core;
using ForJakub.core.domain;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.objectsCSV;

internal class EntryCSV : IDataCSV<Entry>
{
    public double PointsGain { get; set; }
    public int PlayerPlacement { get; set; }
    public ulong PlayerID { get; set; }
    public string PlayerName { get; set; }
    public double PlayerCurrentPoints { get; set; }
    
    public EntryCSV()
    {
        PointsGain = 0;
        PlayerPlacement = 0;
        PlayerID = 0;
        PlayerName = "";
        PlayerCurrentPoints = 0;
    }
    
    public EntryCSV(Entry entry)
    {
        PointsGain = entry.PointsGain;
        PlayerPlacement = entry.PlayerPlacement;
        PlayerID = entry.Player.PlayerID;
        PlayerName = entry.Player.PlayerName;
        PlayerCurrentPoints = entry.Player.PlayerCurrentPoints;
    }
}
using ForJakub.core;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.objectsCSV;

internal class EntryCSV (Entry entry) : IDataCSV<Entry>
{
    public double PointsGain { get; } = entry.PointsGain;
    public int PlayerPlacement { get; } = entry.PlayerPlacement;
    public ulong PlayerID { get; } = entry.Player.PlayerID;
    public string PlayerName { get; } = entry.Player.PlayerName;
    public double PlayerCurrentPoints { get; } = entry.Player.PlayerCurrentPoints;
    
}
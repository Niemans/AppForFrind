using ForJakub.core;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.objectsCSV;

internal class PlayerCSV(Player player) : IDataCSV<Player>
{
    public ulong PlayerID { get; } = player.PlayerID;
    public string PlayerName { get;} = player.PlayerName;
    public double PlayerCurrentPoints { get;} = player.PlayerCurrentPoints;
}
using ForJakub.core;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.objectsCSV;

internal class PlayerCSV : IDataCSV<Player>
{
    public ulong PlayerID { get; set; }
    public string PlayerName { get; set; }
    public double PlayerCurrentPoints { get; set; }

    public PlayerCSV()
    {
        PlayerID = 0;
        PlayerName = "";
        PlayerCurrentPoints = 0;
    }

    public PlayerCSV(Player player)
    {
        PlayerID = player.PlayerID;
        PlayerName = player.PlayerName;
        PlayerCurrentPoints = player.PlayerCurrentPoints;
    }
}
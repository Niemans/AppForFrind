using ForJakub.core;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal class PlayerMapper : IMapper<PlayerCSV, Player>
{
    public Player Map(PlayerCSV source) => new(
        playerID: source.PlayerID,
        playerName: source.PlayerName,
        playerCurrentPoints: source.PlayerCurrentPoints
    );
    
    public PlayerCSV Map(Player source) => new(source);

    public List<Player> MapToList(PlayerCSV source) => [Map(source)];

    public List<PlayerCSV> MapToList(Player source) => [Map(source)];
}
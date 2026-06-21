using ForJakub.core;
using ForJakub.core.domain;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal sealed class PlayerMapper : IMapper<Player, PlayerCSV>
{
    public Player Map(PlayerCSV source) => new(
        PlayerID: source.PlayerID,
        PlayerName: source.PlayerName,
        PlayerCurrentPoints: source.PlayerCurrentPoints
    );
    
    public PlayerCSV Map(Player source) => new(source);

    public List<Player> MapToList(PlayerCSV source) => [Map(source)];

    public List<PlayerCSV> MapToList(Player source) => [Map(source)];
}
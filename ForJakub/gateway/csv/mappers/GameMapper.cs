using ForJakub.core;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal sealed class GameMapper : IMapper<Game, GameCSV>
{
    public Game Map(GameCSV source) => new
    (
        gameId: source.GameID,
        time: source.Time,
        comment: source.Comment,
        entries:
        [ new Entry
        (
            playerPlacement: source.PlayerPlacement,
            pointsGain: source.PlayerCurrentPoints,
            player: new Player
            (
                playerID: source.PlayerID,
                playerName: source.PlayerName,
                playerCurrentPoints: source.PlayerCurrentPoints
            )
        )]
    );
    

    public GameCSV Map(Game source) => throw new InvalidOperationException();

    public List<Game> MapToList(GameCSV source) => [Map(source)];

    public List<GameCSV> MapToList(Game source)
    {
        List<GameCSV> games = [];
        for(var i = 0; i < source.playerEntries.Count; i++)
        {
            games.Add(new GameCSV(source, i));
        }
        return games;
    }
}
using ForJakub.core.domain.game;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal sealed class GameMapper : IMapper<Game, GameCSV>
{
    public Game Map(GameCSV source) => new
    (
        GameID: source.GameID,
        Time: source.Time,
        Comment: source.Comment,
        playerEntries: [ new Entry
        (
            PlayerPlacement: source.PlayerPlacement,
            PointsGain: source.PointsGain,
            Player: new Player
            (
                PlayerID: source.PlayerID,
                PlayerName: source.PlayerName,
                PlayerCurrentPoints: source.PlayerCurrentPoints
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
using ForJakub.core;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal class EntryMapper : IMapper<EntryCSV, Entry>
{
    public Entry Map(EntryCSV source) => new(
        playerPlacement: source.PlayerPlacement,
        pointsGain: source.PointsGain,
        player: new Player(
            playerID: source.PlayerID,
            playerName: source.PlayerName,
            playerCurrentPoints: source.PlayerCurrentPoints
        )
    );

    public EntryCSV Map(Entry source) => new(source);
    
    public List<Entry> MapToList(EntryCSV source) => [Map(source)];

    public List<EntryCSV> MapToList(Entry source) => [Map(source)];
}
using ForJakub.core.domain.game;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal sealed class EntryMapper : IMapper<Entry, EntryCSV>
{
    public Entry Map(EntryCSV source) => new(
        PlayerPlacement: source.PlayerPlacement,
        PointsGain: source.PointsGain,
        Player: new Player(
            PlayerID: source.PlayerID,
            PlayerName: source.PlayerName,
            PlayerCurrentPoints: source.PlayerCurrentPoints
        )
    );

    public EntryCSV Map(Entry source) => new(source);
    
    public List<Entry> MapToList(EntryCSV source) => [Map(source)];

    public List<EntryCSV> MapToList(Entry source) => [Map(source)];
}
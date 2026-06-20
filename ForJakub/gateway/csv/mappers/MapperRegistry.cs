using ForJakub.core;
using ForJakub.core.interfaces;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal static class MapperRegistry

{
    private static IMapper<PlayerCSV, Player> PlayerMapper = new PlayerMapper();
    private static IMapper<EntryCSV, Entry> EntryMapper = new EntryMapper();
    private static IMapper<GameCSV, Game> GameMapper = new GameMapper();

    private static readonly Dictionary<Type, IMapper> Mappers = new()
    {
        [typeof(PlayerCSV)] = PlayerMapper,
        [typeof(EntryCSV)] = EntryMapper,
        [typeof(GameCSV)] = GameMapper
    };

    public static IMapper<T, U> GetMapper<T, U>() 
        where T : IDataCSV<U> 
        where U : IData
    {
        return (IMapper<T, U>)Mappers[typeof(T)];
    }
    
}
using ForJakub.core;
using ForJakub.core.domain;
using ForJakub.core.interfaces;
using ForJakub.gateway.csv.objectsCSV;
using ForJakub.gateway.interfaces;

namespace ForJakub.gateway.csv.mappers;

internal static class MapperRegistry

{
    private static readonly IMapper<Player, PlayerCSV> PlayerMapper = new PlayerMapper();
    private static readonly IMapper<Entry, EntryCSV> EntryMapper = new EntryMapper();
    private static readonly IMapper<Game, GameCSV> GameMapper = new GameMapper();

    private static readonly Dictionary<Type, IMapper> Mappers = new()
    {
        [typeof(Player)] = PlayerMapper,
        [typeof(Entry)] = EntryMapper,
        [typeof(Game)] = GameMapper
    };

    private static IMapper<T, U> GetMapper<T,U> () 
        where T : IData
        where U : IDataCSV<T>
    {
        return (IMapper<T, U>)Mappers[typeof(T)];
    }
    
    public static T Map <T,U>(U data)
        where T : IData
        where U : IDataCSV<T>
    {
        return GetMapper<T,U>().Map(data);
    }

    public static U Map <T,U>(T data)
        where T : IData
        where U : IDataCSV<T>
    {
        return GetMapper<T,U>().Map(data);
    }

    public static List<T> MapToList <T,U>(U data)
        where T : IData
        where U : IDataCSV<T>
    {
        return GetMapper<T,U>().MapToList(data);
    }

    public static List<U> MapToList <T,U>(T data)
        where T : IData
        where U : IDataCSV<T>
    {
        return GetMapper<T,U>().MapToList(data);
    }
}
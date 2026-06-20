using ForJakub.core.interfaces;

namespace ForJakub.gateway.interfaces;

internal interface IMapper;

internal interface IMapper<T,U> : IMapper
    where T : IData
    where U : IDataCSV<T>
{
    T Map(U  source);
    U Map(T source);
    List<T> MapToList(U source);
    List<U> MapToList(T source);
}
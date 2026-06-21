namespace ForJakub.gateway.interfaces;

internal interface IHandler<T> : ISave<T>, IRead<T>;
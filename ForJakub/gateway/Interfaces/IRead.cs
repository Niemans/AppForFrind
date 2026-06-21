namespace ForJakub.gateway.interfaces;

internal interface IRead<out T>
{
    public IEnumerable<T> Read();
}
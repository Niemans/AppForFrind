
namespace ForJakub.gateway.Interfaces
{
    internal interface INames<T> where T : Enum
    {
        public static abstract string GetFriendlyName(T enumName);

        public static abstract string GetFieldName(T enumName);
    }
}

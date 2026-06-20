namespace ForJakub.gateway.interfaces
{
    internal interface ISave<in T>
    {
        public bool Save(T data);
        
        public bool SaveFile(IEnumerable<T> data);
    }
}

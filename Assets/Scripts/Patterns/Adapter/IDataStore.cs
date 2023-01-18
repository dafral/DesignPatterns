namespace Patterns.Adapter
{
    public interface IDataStore
    {
        void SetData<T>(T data, string name);
        T GetData<T>(string name);
    }
}

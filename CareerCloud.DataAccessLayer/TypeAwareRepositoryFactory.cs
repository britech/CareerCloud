namespace CareerCloud.DataAccessLayer;

public class TypeAwareRepositoryFactory
{
    private readonly Dictionary<Type, object> _repositories;

    public TypeAwareRepositoryFactory()
    {
        _repositories = [];
    }

    public void RegisterRepository<T>(IDataRepository<T> repository)
    {
        _repositories.Add(typeof(T), repository);
    }

    public IDataRepository<T> GetRepository<T>()
    {
        Type type = typeof(T);
        if (_repositories.TryGetValue(type, out object? value))
            return (value as IDataRepository<T>)!;
        else
            throw new Exception($"No available repository for type {nameof(type)}");
    }
}

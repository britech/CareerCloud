namespace CareerCloud.DataAccessLayer;

public class TypeAwareRepositoryFactory
{
    private readonly Dictionary<Type, object> _repositories;

    public TypeAwareRepositoryFactory(Dictionary<Type, object> repositories)
    {
        if (!repositories.AsEnumerable().All(e =>
        {
            var valueType = e.Value.GetType();
            return typeof(IDataRepository<>) == valueType;
        }))
        {
            throw new ArgumentException("All repositories must extend from IDataRepository.");
        }
        
        _repositories = repositories;
    }

    public TypeAwareRepositoryFactory() : this([])
    {

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

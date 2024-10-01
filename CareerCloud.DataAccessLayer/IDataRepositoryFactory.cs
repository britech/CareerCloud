namespace CareerCloud.DataAccessLayer;

public class IDataRepositoryFactory
{
    private readonly Dictionary<Type, object> _repositories = [];
    
    public virtual void RegisterRepository<T>(IDataRepository<T> repository)
    {
        _repositories.Add(typeof(T), repository);
    }

    public virtual IDataRepository<T> GetRepository<T>()
    {
        Type key = typeof(T);
        object? value = _repositories[key];

        if (value is IDataRepository<T>)
            return (value as IDataRepository<T>)!;
        else
            throw new Exception($"No repository available for type {nameof(key)}");
    }
}

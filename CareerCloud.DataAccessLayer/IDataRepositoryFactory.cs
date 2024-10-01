namespace CareerCloud.DataAccessLayer;

public class IDataRepositoryFactory
{
    private readonly List<object> _repositories = [];

    public virtual void RegisterRepository<T>(IDataRepository<T> repository)
    {
        _repositories.Add(repository);
    }

    public virtual IDataRepository<T> GetRepository<T>()
    {
        foreach (object item in _repositories)
        {
            if (item is IDataRepository<T> repository)
            {
                return repository;
            }
        }
        throw new Exception($"No repository available for type {nameof(T)}");
    }
}

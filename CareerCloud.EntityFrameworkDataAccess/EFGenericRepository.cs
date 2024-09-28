using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class EFGenericRepository<T>(TypeAwareRepositoryFactory factory) : IDataRepository<T>
    where T : class
{
    private TypeAwareRepositoryFactory Factory { get; init; } = factory;

    public EFGenericRepository()
        : this(new EFRepositoryFactory(new CareerCloudContextFactory(new CareerCloudConfigResolver(DefaultConfigurationLoader.Instance.Configuration))))
    {

    }

    public void Add(params T[] items)
    {
        Factory.GetRepository<T>().Add(items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
    {
        return Factory.GetRepository<T>().GetSingle(where, navigationProperties);
    }

    public void Remove(params T[] items)
    {
        Factory.GetRepository<T>().Remove(items);
    }

    public void Update(params T[] items)
    {
        Factory.GetRepository<T>().Update(items);
    }
}

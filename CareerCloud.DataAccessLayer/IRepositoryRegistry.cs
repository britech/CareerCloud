namespace CareerCloud.DataAccessLayer
{
    public interface IRepositoryRegistry<T>
    {
        IRepository GetRepository(T id);
    }
}

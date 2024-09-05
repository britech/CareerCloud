namespace CareerCloud.DataAccessLayer
{
    public interface IRepositoryFactory<TId>
    {
        IRepository GetRepository(TId id);
    }
}

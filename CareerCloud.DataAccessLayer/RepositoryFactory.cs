namespace CareerCloud.DataAccessLayer
{
    public abstract class RepositoryFactory<TId>
    {
        public abstract IRepository GetRepository(TId id);
    }
}

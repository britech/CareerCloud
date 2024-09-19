namespace CareerCloud.DataAccessLayer
{
    public interface IRepositoryFactory
    {
        IRepository GetRepository();
    }
}

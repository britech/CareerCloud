namespace CareerCloud.DataAccessLayer
{
    public class TypeAwareRepositoryFactory<T>(TypeAwareRepositoryRegistry registry) : IRepositoryFactory
        where T : class
    {
        private readonly TypeAwareRepositoryRegistry _registry = registry;

        public IRepository GetRepository()
        {
            return _registry.GetRepository(typeof(T));
        }
    }
}

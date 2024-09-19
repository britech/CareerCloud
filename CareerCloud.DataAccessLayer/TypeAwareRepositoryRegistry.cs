namespace CareerCloud.DataAccessLayer
{
    public class TypeAwareRepositoryRegistry : IRepositoryRegistry<Type>
    {
        private readonly IDictionary<Type, IRepository> _repositories;

        public TypeAwareRepositoryRegistry()
        {
            _repositories = new Dictionary<Type, IRepository>();
        }

        public TypeAwareRepositoryRegistry(IDictionary<Type, IRepository> repositories)
        {
            _repositories = repositories;
        }

        public void RegisterRepository(Type type, IRepository repository)
        {
            _repositories.Add(type, repository);
        }

        public IRepository GetRepository(Type id)
        {
            return _repositories.ContainsKey(id) ? _repositories[id] : null!;
        }
    }
}

﻿namespace CareerCloud.DataAccessLayer
{
    public class BaseRepositoryRegistry : IRepositoryFactory<Type>
    {
        private readonly IDictionary<Type, IRepository> _repositories;

        public BaseRepositoryRegistry()
        {
            _repositories = new Dictionary<Type, IRepository>();
        }

        public BaseRepositoryRegistry(IDictionary<Type, IRepository> repositories)
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
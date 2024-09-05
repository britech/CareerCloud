using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T>
        where T : class
    {
        private readonly EFRepositoryRegistry factory = EFRepositoryRegistry.Instance;
        private readonly ICrudRepository<T> _repository;

        public EFGenericRepository()
        {
            _repository = (factory.GetRepository(typeof(T)) as ICrudRepository<T>)!;   
        }

        public void Add(params T[] items)
        {
            _repository.AddAll(items);
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
            return _repository.FindOne(where);
        }

        public void Remove(params T[] items)
        {
            _repository.RemoveAll(items);
        }

        public void Update(params T[] items)
        {
            _repository.UpdateAll(items);
        }
    }
}

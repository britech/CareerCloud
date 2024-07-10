using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseRepository<T> : IDataRepository<T>
    {
        protected const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=JOB_PORTAL_DB;Integrated Security=true";
        
        public abstract void Add(params T[] items);
        public abstract void CallStoredProc(string name, params Tuple<string, string>[] parameters);
        public abstract IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        public abstract IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract void Remove(params T[] items);
        public abstract void Update(params T[] items);
    }
}

using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class BaseRepositoryImpl<T> : IDataRepository<T>
        where T : class
    {
        private readonly DbHelper _dbHelper;

        protected string InsertQuery { get; private set; }
        protected string UpdateQuery { get; private set; }
        protected string DeleteQuery { get; private set; }
        protected string SelectQuery { get; private set; }
        protected IDbCommandParameterSetter<T> UpdateCmdParameterSetter { get; private set; }
        protected IDbCommandParameterSetter<T> DeleteCmdParameterSetter { get; private set; }
        protected IDbRowMapper<T> RowMapper { get; set; }

        public BaseRepositoryImpl(string InsertQuery, string UpdateQuery, string DeleteQuery, string SelectQuery,
            IDbCommandParameterSetter<T> UpdateCmdParameterSetter, 
            IDbCommandParameterSetter<T> DeleteCmdParameterSetter,
            IDbRowMapper<T> rowMapper) 
        {
            _dbHelper = new DbHelper(ApplicationConstants.CONNECTION_STRING);
            
            this.InsertQuery = InsertQuery;
            this.UpdateQuery = UpdateQuery;
            this.DeleteQuery = DeleteQuery;
            this.SelectQuery = SelectQuery;
            this.UpdateCmdParameterSetter = UpdateCmdParameterSetter;
            this.DeleteCmdParameterSetter = DeleteCmdParameterSetter;
            this.RowMapper = rowMapper;
        }

        public void Add(params T[] items)
        {
            _dbHelper.Update(InsertQuery, UpdateCmdParameterSetter, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            return _dbHelper.Query(SelectQuery, RowMapper);
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as T)!;
        }

        public void Remove(params T[] items)
        {
            _dbHelper.Update(DeleteQuery, DeleteCmdParameterSetter, items);
        }

        public void Update(params T[] items)
        {
            _dbHelper.Update(UpdateQuery, UpdateCmdParameterSetter, items);
        }
    }
}

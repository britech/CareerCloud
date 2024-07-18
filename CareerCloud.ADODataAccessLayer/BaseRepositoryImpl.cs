using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class BaseRepositoryImpl<T> : IDataRepository<T>
        where T : class
    {
        private DbHelper DbHelper { get; init; }
        private string InsertQuery { get; init; }
        private string UpdateQuery { get; init; }
        private string DeleteQuery { get; init; }
        private string SelectQuery { get; init; }
        private IDbCommandParameterSetter<T> UpdateCmdParameterSetter { get; init; }
        private IDbCommandParameterSetter<T> DeleteCmdParameterSetter { get; init; }
        private IDbRowMapper<T> RowMapper { get; init; }

        public BaseRepositoryImpl(string InsertQuery, string UpdateQuery, string DeleteQuery, string SelectQuery,
            IDbCommandParameterSetter<T> UpdateCmdParameterSetter, 
            IDbCommandParameterSetter<T> DeleteCmdParameterSetter,
            IDbRowMapper<T> rowMapper) : 
            this(new DbHelper(ApplicationConstants.CONNECTION_STRING), InsertQuery, UpdateQuery, DeleteQuery, SelectQuery,
                UpdateCmdParameterSetter, DeleteCmdParameterSetter, rowMapper)
        {
            
        }

        public BaseRepositoryImpl(DbHelper dbHelper, 
            string InsertQuery, string UpdateQuery, string DeleteQuery, string SelectQuery, 
            IDbCommandParameterSetter<T> UpdateCmdParameterSetter, 
            IDbCommandParameterSetter<T> DeleteCmdParameterSetter, 
            IDbRowMapper<T> RowMapper)
        {
            this.DbHelper = dbHelper;
            this.InsertQuery = InsertQuery;
            this.UpdateQuery = UpdateQuery;
            this.DeleteQuery = DeleteQuery;
            this.SelectQuery = SelectQuery;
            this.UpdateCmdParameterSetter = UpdateCmdParameterSetter;
            this.DeleteCmdParameterSetter = DeleteCmdParameterSetter;
            this.RowMapper = RowMapper;
        }
        
        public virtual void Add(params T[] items)
        {
            DbHelper.Update(InsertQuery, UpdateCmdParameterSetter, items);
        }

        public virtual void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            return DbHelper.Query(SelectQuery, RowMapper);
        }

        public virtual IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as T)!;
        }

        public virtual void Remove(params T[] items)
        {
            DbHelper.Update(DeleteQuery, DeleteCmdParameterSetter, items);
        }

        public virtual void Update(params T[] items)
        {
            DbHelper.Update(UpdateQuery, UpdateCmdParameterSetter, items);
        }
    }
}

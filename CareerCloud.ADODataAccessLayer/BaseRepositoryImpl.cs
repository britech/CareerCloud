using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class BaseRepositoryImpl<T>(DbHelper DbHelper,
        string InsertQuery, string UpdateQuery, string DeleteQuery, string SelectQuery,
        IDbCommandParameterSetter<T> UpdateCmdParameterSetter,
        IDbCommandParameterSetter<T> DeleteCmdParameterSetter,
        IDbRowMapper<T> RowMapper) : IDataRepository<T>
        where T : class
    {
        private DbHelper DbHelper { get; init; } = DbHelper;
        private string InsertQuery { get; init; } = InsertQuery;
        private string UpdateQuery { get; init; } = UpdateQuery;
        private string DeleteQuery { get; init; } = DeleteQuery;
        private string SelectQuery { get; init; } = SelectQuery;
        private IDbCommandParameterSetter<T> UpdateCmdParameterSetter { get; init; } = UpdateCmdParameterSetter;
        private IDbCommandParameterSetter<T> DeleteCmdParameterSetter { get; init; } = DeleteCmdParameterSetter;
        private IDbRowMapper<T> RowMapper { get; init; } = RowMapper;

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

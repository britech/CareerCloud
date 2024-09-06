using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : IDataRepository<SecurityRolePoco>
    {
        private readonly DbHelper _dbHelper;

        public SecurityRoleRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params SecurityRolePoco[] items)
        {
            _dbHelper.Update("insert into dbo.security_roles(id, role, is_inactive) values(@id, @role, @is_inactive)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@role", item.Role));
                    cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, role, is_inactive from dbo.security_roles",
                reader =>
                {
                    return new SecurityRolePoco()
                    {
                        Id = reader.GetGuid(0),
                        Role = reader.GetString(1),
                        IsInactive = reader.GetBoolean(2)
                    };
                });
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as SecurityRolePoco)!;
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            _dbHelper.Update("delete from dbo.security_roles where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params SecurityRolePoco[] items)
        {
            _dbHelper.Update("update dbo.security_roles set role = @role, is_inactive = @is_inactive where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@role", item.Role));
                    cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
                }, items);
        }
    }
}

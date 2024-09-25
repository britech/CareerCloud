using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class SecurityLoginsRoleRepository : IDataRepository<SecurityLoginsRolePoco>
{
    private readonly DbHelper _dbHelper;

    public SecurityLoginsRoleRepository()
        : this(new DbHelper(new CareerCloudConfigResolver(DefaultConfigurationLoader.Instance.Configuration)))
    {

    }

    public SecurityLoginsRoleRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params SecurityLoginsRolePoco[] items)
    {
        _dbHelper.Update("insert into dbo.security_logins_roles(id, login, role) values(@id, @login, @role)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@role", item.Role));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, login, role, time_stamp from dbo.security_logins_roles",
            reader =>
            {
                return new SecurityLoginsRolePoco()
                {
                    Id = reader.GetGuid(0),
                    Login = reader.GetGuid(1),
                    Role = reader.GetGuid(2),
                    TimeStamp = reader.GetValue(3) as byte[] ?? null
                };
            });
    }

    public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as SecurityLoginsRolePoco)!;
    }

    public void Remove(params SecurityLoginsRolePoco[] items)
    {
        _dbHelper.Update("delete from dbo.security_logins_roles where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params SecurityLoginsRolePoco[] items)
    {
        _dbHelper.Update("update dbo.security_logins_roles set login = @login, role = @role where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@role", item.Role));
            }, items);
    }
}

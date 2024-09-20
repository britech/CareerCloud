using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class SecurityLoginsLogRepository : IDataRepository<SecurityLoginsLogPoco>
{
    private readonly DbHelper _dbHelper;

    public SecurityLoginsLogRepository()
        : this(new DbHelper(CareerCloudConfigResolver.Instance))
    {
        
    }

    public SecurityLoginsLogRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params SecurityLoginsLogPoco[] items)
    {
        _dbHelper.Update("insert into dbo.security_logins_log(id, login, source_ip, logon_date, is_succesful) values(@id, @login, @source_ip, @logon_date, @is_succesful)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@source_ip", item.SourceIP));
                cmd.Parameters.Add(new SqlParameter("@logon_date", item.LogonDate));
                cmd.Parameters.Add(new SqlParameter("@is_succesful", item.IsSuccesful));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, login, source_ip, logon_date, is_succesful from dbo.security_logins_log",
            reader =>
            {
                return new SecurityLoginsLogPoco()
                {
                    Id = reader.GetGuid(0),
                    Login = reader.GetGuid(1),
                    SourceIP = reader.GetString(2),
                    LogonDate = reader.GetDateTime(3),
                    IsSuccesful = reader.GetBoolean(4)
                };
            });
    }

    public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as SecurityLoginsLogPoco)!;
    }

    public void Remove(params SecurityLoginsLogPoco[] items)
    {
        _dbHelper.Update("delete from dbo.security_logins_log where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params SecurityLoginsLogPoco[] items)
    {
        _dbHelper.Update("update dbo.security_logins_log set login = @login, source_ip = @source_ip, logon_date = @logon_date, is_succesful = @is_succesful where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@source_ip", item.SourceIP));
                cmd.Parameters.Add(new SqlParameter("@logon_date", item.LogonDate));
                cmd.Parameters.Add(new SqlParameter("@is_succesful", item.IsSuccesful));
            }, items);
    }
}

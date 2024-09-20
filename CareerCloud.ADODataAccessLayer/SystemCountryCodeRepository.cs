using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
{
    private readonly DbHelper _dbHelper;
    
    public SystemCountryCodeRepository()
        : this(new DbHelper(CareerCloudConfigResolver.Instance))
    {
        
    }

    public SystemCountryCodeRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params SystemCountryCodePoco[] items)
    {
        _dbHelper.Update("insert into dbo.system_country_codes(code, name) values(@code, @name)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@code", value: item.Code));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@name", value: item.Name));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select code, name from dbo.system_country_codes",
            reader =>
            {
                return new SystemCountryCodePoco()
                {
                    Code = reader.GetString(0),
                    Name = reader.GetString(1)
                };
            });
    }

    public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as SystemCountryCodePoco)!;
    }

    public void Remove(params SystemCountryCodePoco[] items)
    {
        _dbHelper.Update("delete from dbo.system_country_codes where code = @code",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@code", value: item.Code));
            }, items);
    }

    public void Update(params SystemCountryCodePoco[] items)
    {
        _dbHelper.Update("update dbo.system_country_codes set name = @name where code = @code",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@code", value: item.Code));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@name", value: item.Name));
            }, items);
    }
}

using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class CompanyJobRepository : IDataRepository<CompanyJobPoco>
{
    private readonly DbHelper _dbHelper;

    public CompanyJobRepository()
        : this(new DbHelper(new CareerCloudConfigResolver(CareerCloudIniLoader.LoadConfiguration())))
    {
        
    }

    public CompanyJobRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params CompanyJobPoco[] items)
    {
        _dbHelper.Update("insert into dbo.company_jobs(id, company, profile_created, is_inactive, is_company_hidden) values(@id, @company, @profile_created, @is_inactive, @is_company_hidden)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@profile_created", item.ProfileCreated));
                cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
                cmd.Parameters.Add(new SqlParameter("@is_company_hidden", item.IsCompanyHidden));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, company, profile_created, is_inactive, is_company_hidden, time_stamp from dbo.company_jobs",
            reader =>
            {
                return new CompanyJobPoco()
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    ProfileCreated = reader.GetDateTime(2),
                    IsInactive = reader.GetBoolean(3),
                    IsCompanyHidden = reader.GetBoolean(4),
                    TimeStamp = reader.GetValue(5) as byte[] ?? []
                };
            });
    }

    public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyJobPoco)!;
    }

    public void Remove(params CompanyJobPoco[] items)
    {
        _dbHelper.Update("delete from dbo.company_jobs where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params CompanyJobPoco[] items)
    {
        _dbHelper.Update("update dbo.company_jobs set company = @company, profile_created = @profile_created, is_inactive = @is_inactive, is_company_hidden = @is_company_hidden where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@profile_created", item.ProfileCreated));
                cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
                cmd.Parameters.Add(new SqlParameter("@is_company_hidden", item.IsCompanyHidden));
            }, items);
    }
}

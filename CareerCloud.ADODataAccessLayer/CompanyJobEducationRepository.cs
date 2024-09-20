using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class CompanyJobEducationRepository : IDataRepository<CompanyJobEducationPoco>
{
    private readonly DbHelper _dbHelper;
    
    public CompanyJobEducationRepository()
        : this(new DbHelper(CareerCloudConfigResolver.Instance))
    {
        
    }

    public CompanyJobEducationRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, job, major, importance, time_stamp from dbo.company_job_educations",
            reader =>
            {
                return new CompanyJobEducationPoco()
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    Major = reader.GetString(2),
                    Importance = reader.GetInt16(3),
                    TimeStamp = reader.GetValue(4) as byte[] ?? []
                };
            });
    }

    public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyJobEducationPoco)!;
    }

    public void Add(params CompanyJobEducationPoco[] items)
    {
        _dbHelper.Update("insert into dbo.company_job_educations(id, job, major, importance) values(@id, @job, @major, @importance)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                cmd.Parameters.Add(new SqlParameter("@major", item.Major));
                cmd.Parameters.Add(new SqlParameter("@importance", item.Importance));
            }, items);
    }

    public void Update(params CompanyJobEducationPoco[] items)
    {
        _dbHelper.Update("update dbo.company_job_educations set job = @job, major = @major, importance = @importance where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                cmd.Parameters.Add(new SqlParameter("@major", item.Major));
                cmd.Parameters.Add(new SqlParameter("@importance", item.Importance));
            }, items);
    }

    public void Remove(params CompanyJobEducationPoco[] items)
    {
        _dbHelper.Update("delete from dbo.company_job_educations where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }
}

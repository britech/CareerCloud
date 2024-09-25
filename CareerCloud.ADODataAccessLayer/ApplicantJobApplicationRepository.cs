using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>
{
    private readonly DbHelper _dbHelper;

    public ApplicantJobApplicationRepository()
        : this(new DbHelper(new CareerCloudConfigResolver(DefaultConfigurationLoader.Instance.Configuration)))
    {

    }

    public ApplicantJobApplicationRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params ApplicantJobApplicationPoco[] items)
    {
        _dbHelper.Update("insert into dbo.applicant_job_applications(id, applicant, job, application_date) values(@id, @applicant, @job, @application_date)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@job", value: item.Job));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@application_date", value: item.ApplicationDate));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, applicant, job, application_date, time_stamp from dbo.applicant_job_applications",
            (reader) =>
            {
                return new ApplicantJobApplicationPoco()
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Job = reader.GetGuid(2),
                    ApplicationDate = reader.GetDateTime(3),
                    TimeStamp = reader.GetValue(4) as byte[] ?? []
                };
            });
    }

    public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantJobApplicationPoco)!;
    }

    public void Remove(params ApplicantJobApplicationPoco[] items)
    {
        _dbHelper.Update("delete from dbo.applicant_job_applications where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params ApplicantJobApplicationPoco[] items)
    {
        _dbHelper.Update("update dbo.applicant_job_applications set applicant = @applicant, job = @job, application_date = @application_date where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@job", value: item.Job));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@application_date", value: item.ApplicationDate));
            }, items);
    }
}

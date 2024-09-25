using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
{
    private readonly DbHelper _dbHelper;
    
    public ApplicantEducationRepository()
        : this(new DbHelper(new CareerCloudConfigResolver(DefaultConfigurationLoader.Instance.Configuration)))
    {
        
    }

    public ApplicantEducationRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params ApplicantEducationPoco[] items)
    {
        _dbHelper.Update("insert into dbo.applicant_educations(id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent) values(@id, @applicant, @major, @certificate_diploma, @start_date, @completion_date, @completion_Percent)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@major", value: item.Major));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@certificate_diploma", value: item.CertificateDiploma));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@start_date", value: item.StartDate));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@completion_date", value: item.CompletionDate));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@completion_percent", value: item.CompletionPercent));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent, time_stamp from dbo.applicant_educations", (reader) =>
        {
            return new ApplicantEducationPoco
            {
                Id = reader.GetGuid(0),
                Applicant = reader.GetGuid(1),
                Major = reader.GetString(2),
                CertificateDiploma = reader.GetValue(3) as string ?? null,
                StartDate = reader.GetValue(4) as DateTime?,
                CompletionDate = reader.GetValue(5)  as DateTime?,
                CompletionPercent = reader.GetValue(6) as Byte?,
                TimeStamp = reader.GetValue(7) as byte[] ?? []
            };
        });
    }

    public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantEducationPoco)!;
    }

    public void Remove(params ApplicantEducationPoco[] items)
    {
        _dbHelper.Update("delete from dbo.applicant_educations where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params ApplicantEducationPoco[] items)
    {
        _dbHelper.Update("update dbo.applicant_educations set applicant = @applicant, major = @major, certificate_diploma = @certificate_diploma, start_date = @start_date, completion_date = @completion_date, completion_percent = @completion_percent where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@major", value: item.Major));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@certificate_diploma", value: item.CertificateDiploma));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@start_date", value: item.StartDate));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@completion_date", value: item.CompletionDate));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@completion_percent", value: item.CompletionPercent));
            }, items);
    }
}

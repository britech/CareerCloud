using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>
    {
        private readonly DbHelper _dbHelper;

        public ApplicantWorkHistoryRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            _dbHelper.Update("insert into applicant_work_history(id, applicant, company_name, country_code, location, job_title, job_description, start_month, start_year, end_month, end_year) values(@id, @applicant, @company_name, @country_code, @location, @job_title, @job_description, @start_month, @start_year, @end_month, @end_year)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                    cmd.Parameters.Add(new SqlParameter("@company_name", item.CompanyName));
                    cmd.Parameters.Add(new SqlParameter("@country_code", item.CountryCode));
                    cmd.Parameters.Add(new SqlParameter("@location", item.Location));
                    cmd.Parameters.Add(new SqlParameter("@job_title", item.JobTitle));
                    cmd.Parameters.Add(new SqlParameter("@job_description", item.JobDescription));
                    cmd.Parameters.Add(new SqlParameter("@start_month", item.StartMonth));
                    cmd.Parameters.Add(new SqlParameter("@start_year", item.StartYear));
                    cmd.Parameters.Add(new SqlParameter("@end_month", item.EndMonth));
                    cmd.Parameters.Add(new SqlParameter("@end_year", item.EndYear));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, applicant, company_name, country_code, location, job_title, job_description, start_month, start_year, end_month, end_year, time_stamp from applicant_work_history", 
                (reader) =>
                {
                    return new ApplicantWorkHistoryPoco()
                    {
                        Id = reader.GetGuid(0),
                        Applicant = reader.GetGuid(1),
                        CompanyName = reader.GetString(2),
                        CountryCode = reader.GetString(3),
                        Location = reader.GetString(4),
                        JobTitle = reader.GetString(5),
                        JobDescription = reader.GetString(6),
                        StartMonth = reader.GetInt16(7),
                        StartYear = reader.GetInt32(8),
                        EndMonth = reader.GetInt16(9),
                        EndYear = reader.GetInt32(10),
                        TimeStamp = reader.GetValue(11) as byte[] ?? []
                    };
                });
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantWorkHistoryPoco)!;
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            _dbHelper.Update("delete from applicant_work_history where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            _dbHelper.Update("update applicant_work_history set applicant = @applicant, company_name = @company_name, country_code = @country_code, location = @location, job_title = @job_title, job_description = @job_description, start_month = @start_month, start_year = @start_year, end_month = @end_month, end_year = @end_year where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                    cmd.Parameters.Add(new SqlParameter("@company_name", item.CompanyName));
                    cmd.Parameters.Add(new SqlParameter("@country_code", item.CountryCode));
                    cmd.Parameters.Add(new SqlParameter("@location", item.Location));
                    cmd.Parameters.Add(new SqlParameter("@job_title", item.JobTitle));
                    cmd.Parameters.Add(new SqlParameter("@job_description", item.JobDescription));
                    cmd.Parameters.Add(new SqlParameter("@start_month", item.StartMonth));
                    cmd.Parameters.Add(new SqlParameter("@start_year", item.StartYear));
                    cmd.Parameters.Add(new SqlParameter("@end_month", item.EndMonth));
                    cmd.Parameters.Add(new SqlParameter("@end_year", item.EndYear));
                }, items);
        }
    }
}

using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : BaseRepositoryImpl<ApplicantWorkHistoryPoco>
    {
        public ApplicantWorkHistoryRepository() : 
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into applicant_work_history(id, applicant, company_name, country_code, location, job_title, job_description, start_month, start_year, end_month, end_year) values(@id, @applicant, @company_name, @country_code, @location, @job_title, @job_description, @start_month, @start_year, @end_month, @end_year)", 
                "update applicant_work_history set applicant = @applicant, company_name = @company_name, country_code = @country_code, location = @location, job_title = @job_title, job_description = @job_description, start_month = @start_month, start_year = @start_year, end_month = @end_month, end_year = @end_year where id = @id", 
                "delete from applicant_work_history where id = @id", 
                "select id, applicant, company_name, country_code, location, job_title, job_description, start_month, start_year, end_month, end_year, time_stamp from applicant_work_history", 
                new UpdateCmdParameterSetterImpl(), 
                new DeleteCmdParameterSetterImpl(), 
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantWorkHistoryPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantWorkHistoryPoco item)
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
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantWorkHistoryPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantWorkHistoryPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<ApplicantWorkHistoryPoco>
        {
            public ApplicantWorkHistoryPoco MapRow(DbDataReader reader)
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
            }
        }
    }
}

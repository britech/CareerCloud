using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobDescriptionRepository : BaseRepositoryImpl<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionRepository() : 
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into company_jobs_descriptions(id, job, job_name, job_descriptions) values(@id, @job, @job_name, @job_descriptions)", 
                "update company_jobs_descriptions set id = @id, job = @job, job_name = @job_name, job_descriptions = @job_descriptions where id = @id", 
                "delete from company_jobs_descriptions where id = @id", 
                "select id, job, job_name, job_descriptions, time_stamp from company_jobs_descriptions", 
                new UpdateCmdParameterSetterImpl(), 
                new DeleteCmdParameterSetterImpl(), 
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobDescriptionPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobDescriptionPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                cmd.Parameters.Add(new SqlParameter("@job_name", item.JobName));
                cmd.Parameters.Add(new SqlParameter("@job_descriptions", item.JobDescriptions));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobDescriptionPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobDescriptionPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyJobDescriptionPoco>
        {
            public CompanyJobDescriptionPoco MapRow(DbDataReader reader)
            {
                return new CompanyJobDescriptionPoco()
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    JobName = reader.GetString(2),
                    JobDescriptions = reader.GetString(3),
                    TimeStamp = reader.GetValue(4) as byte[] ?? []
                };
            }
        }
    }
}

using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository : BaseRepositoryImpl<CompanyJobEducationPoco>
    {
        public CompanyJobEducationRepository() : 
            base("insert into company_job_educations(id, job, major, importance) values(@id, @job, @major, @importance)", 
                "update company_job_educations set job = @job, major = @major, importance = @importance where id = @id", 
                "delete from company_job_educations where id = @id",
                "select id, job, major, importance, time_stamp from company_job_educations", 
                new UpdateCmdParameterSetterImpl(), 
                new DeleteCmdParameterSetterImpl(), 
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobEducationPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobEducationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                cmd.Parameters.Add(new SqlParameter("@major", item.Major));
                cmd.Parameters.Add(new SqlParameter("@importance", item.Importance));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobEducationPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobEducationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyJobEducationPoco>
        {
            public CompanyJobEducationPoco MapRow(DbDataReader reader)
            {
                return new CompanyJobEducationPoco()
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    Major = reader.GetString(2),
                    Importance = reader.GetInt16(3),
                    TimeStamp = reader.GetValue(4) as byte[] ?? []
                };
            }
        }
    }
}

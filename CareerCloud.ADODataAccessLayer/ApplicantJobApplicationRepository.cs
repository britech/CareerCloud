using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : BaseRepositoryImpl<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into applicant_job_applications(id, applicant, job, application_date) values(@id, @applicant, @job, @application_date)",
                "update applicant_job_applications set applicant = @applicant, job = @job, application_date = @application_date where id = @id",
                "delete from applicant_job_applications where id = @id",
                "select id, applicant, job, application_date, time_stamp from applicant_job_applications",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantJobApplicationPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantJobApplicationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@job", value: item.Job));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@application_date", value: item.ApplicationDate));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantJobApplicationPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantJobApplicationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<ApplicantJobApplicationPoco>
        {
            public ApplicantJobApplicationPoco MapRow(DbDataReader reader)
            {
                return new ApplicantJobApplicationPoco()
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Job = reader.GetGuid(2),
                    ApplicationDate = reader.GetDateTime(3),
                    TimeStamp = reader.GetValue(4) as byte[] ?? []
                };
            }
        }
    }
}

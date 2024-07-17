using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseRepositoryImpl<ApplicantEducationPoco>
    {
        public ApplicantEducationRepository() :
            base("insert into applicant_educations(id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent) values(@id, @applicant, @major, @certificate_diploma, @start_date, @completion_date, @completion_Percent)",
                "update applicant_educations set applicant = @applicant, major = @major, certificate_diploma = @certificate_diploma, start_date = @start_date, completion_date = @completion_date, completion_percent = @completion_percent where id = @id",
                "delete from applicant_educations where id = @id",
                "select id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent, time_stamp from applicant_educations",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParamterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantEducationPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantEducationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@major", value: item.Major));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@certificate_diploma", value: item.CertificateDiploma));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@start_date", value: item.StartDate));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@completion_date", value: item.CompletionDate));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@completion_percent", value: item.CompletionPercent));
            }
        }

        private class DeleteCmdParamterSetterImpl : IDbCommandParameterSetter<ApplicantEducationPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantEducationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<ApplicantEducationPoco>
        {
            public ApplicantEducationPoco MapRow(DbDataReader reader)
            {
                return new ApplicantEducationPoco
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Major = reader.GetString(2),
                    CertificateDiploma = reader.GetString(3),
                    StartDate = reader.GetDateTime(4),
                    CompletionDate = reader.GetDateTime(5),
                    CompletionPercent = reader.GetByte(6),
                    TimeStamp = reader.GetValue(7) as byte[] ?? []
                };
            }
        }
    }
}

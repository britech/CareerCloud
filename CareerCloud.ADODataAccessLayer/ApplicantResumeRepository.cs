using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : BaseRepositoryImpl<ApplicantResumePoco>
    {
        public ApplicantResumeRepository() :
            base("insert into applicant_resumes(id, applicant, resume, last_updated) values(@id, @applicant, @resume, @last_updated)",
                "update applicant_resumes set applicant = @applicant, resume = @resume, last_updated = @last_updated where id = @id",
                "delete from applicant_resumes where id = @id",
                "select id, applicant, resume, last_updated from applicant_resumes",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantResumePoco>
        {
            public void SetValues(DbCommand cmd, ApplicantResumePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                cmd.Parameters.Add(new SqlParameter("@resume", item.Resume));
                cmd.Parameters.Add(new SqlParameter("@last_updated", item.LastUpdated));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantResumePoco>
        {
            public void SetValues(DbCommand cmd, ApplicantResumePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<ApplicantResumePoco>
        {
            public ApplicantResumePoco MapRow(DbDataReader reader)
            {
                return new ApplicantResumePoco()
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Resume = reader.GetString(2),
                    LastUpdated = reader.GetValue(3) as DateTime?
                };
            }
        }
    }
}

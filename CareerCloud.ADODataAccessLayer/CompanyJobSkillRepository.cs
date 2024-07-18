using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : BaseRepositoryImpl<CompanyJobSkillPoco>
    {
        public CompanyJobSkillRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into company_job_skills(id, job, skill, skill_level, importance) values(@id, @job, @skill, @skill_level, @importance)",
                "update company_job_skills set job = @job, skill = @skill, skill_level = @skill_level, importance = @importance where id = @id",
                "delete from company_job_skills where id = @id",
                "select id, job, skill, skill_level, importance, time_stamp from company_job_skills",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobSkillPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobSkillPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                cmd.Parameters.Add(new SqlParameter("@skill", item.Skill));
                cmd.Parameters.Add(new SqlParameter("@skill_level", item.SkillLevel));
                cmd.Parameters.Add(new SqlParameter("@importance", item.Importance));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobSkillPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobSkillPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyJobSkillPoco>
        {
            public CompanyJobSkillPoco MapRow(DbDataReader reader)
            {
                return new CompanyJobSkillPoco()
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    Skill = reader.GetString(2),
                    SkillLevel = reader.GetString(3),
                    Importance = reader.GetInt32(4),
                    TimeStamp = reader.GetValue(5) as byte[] ?? []
                };
            }
        }
    }
}

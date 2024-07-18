using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantSkillRepository : BaseRepositoryImpl<ApplicantSkillPoco>
    {
        public ApplicantSkillRepository():
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into applicant_skills(id, applicant, skill, skill_level, start_month, start_year, end_month, end_year) values(@id, @applicant, @skill, @skill_level, @start_month, @start_year, @end_month, @end_year)", 
                "update applicant_skills set applicant = @applicant, skill = @skill, skill_level = @skill_level, start_month = @start_month, start_year = @start_year, end_month = @end_month, end_year = @end_year where id = @id", 
                "delete from applicant_skills where id = @id", 
                "select id, applicant, skill, skill_level, start_month, start_year, end_month, end_year, time_stamp from applicant_skills", 
                new UpdateCmdParameterSetterImpl(), 
                new DeleteCmdParameterSetterImpl(), 
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantSkillPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantSkillPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                cmd.Parameters.Add(new SqlParameter("@skill", item.Skill));
                cmd.Parameters.Add(new SqlParameter("@skill_level", item.SkillLevel));
                cmd.Parameters.Add(new SqlParameter("@start_month", item.StartMonth));
                cmd.Parameters.Add(new SqlParameter("@start_year", item.StartYear));
                cmd.Parameters.Add(new SqlParameter("@end_month", item.EndMonth));
                cmd.Parameters.Add(new SqlParameter("@end_year", item.EndYear));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantSkillPoco>
        {
            public void SetValues(DbCommand cmd, ApplicantSkillPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<ApplicantSkillPoco>
        {
            public ApplicantSkillPoco MapRow(DbDataReader reader)
            {
                return new ApplicantSkillPoco()
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Skill = reader.GetString(2),
                    SkillLevel = reader.GetString(3),
                    StartMonth = reader.GetByte(4),
                    StartYear = reader.GetInt32(5),
                    EndMonth = reader.GetByte(6),
                    EndYear = reader.GetInt32(7),
                    TimeStamp = reader.GetValue(8) as byte[] ?? []
                };
            }
        }
    }
}

using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantSkillRepository : IDataRepository<ApplicantSkillPoco>
    {
        private readonly DbHelper _dbHelper;

        public ApplicantSkillRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params ApplicantSkillPoco[] items)
        {
            _dbHelper.Update("insert into dbo.applicant_skills(id, applicant, skill, skill_level, start_month, start_year, end_month, end_year) values(@id, @applicant, @skill, @skill_level, @start_month, @start_year, @end_month, @end_year)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                    cmd.Parameters.Add(new SqlParameter("@skill", item.Skill));
                    cmd.Parameters.Add(new SqlParameter("@skill_level", item.SkillLevel));
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, applicant, skill, skill_level, start_month, start_year, end_month, end_year, time_stamp from dbo.applicant_skills",
                (reader) =>
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
                });
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantSkillPoco)!;
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            _dbHelper.Update("delete from dbo.applicant_skills where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            _dbHelper.Update("update dbo.applicant_skills set applicant = @applicant, skill = @skill, skill_level = @skill_level, start_month = @start_month, start_year = @start_year, end_month = @end_month, end_year = @end_year where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                    cmd.Parameters.Add(new SqlParameter("@skill", item.Skill));
                    cmd.Parameters.Add(new SqlParameter("@skill_level", item.SkillLevel));
                    cmd.Parameters.Add(new SqlParameter("@start_month", item.StartMonth));
                    cmd.Parameters.Add(new SqlParameter("@start_year", item.StartYear));
                    cmd.Parameters.Add(new SqlParameter("@end_month", item.EndMonth));
                    cmd.Parameters.Add(new SqlParameter("@end_year", item.EndYear));
                }, items);
        }
    }
}

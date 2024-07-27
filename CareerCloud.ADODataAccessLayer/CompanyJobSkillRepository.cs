using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : IDataRepository<CompanyJobSkillPoco>
    {
        private readonly DbHelper _dbHelper;

        public CompanyJobSkillRepository()
        {
            _dbHelper = new DbHelper(ApplicationConstants.CONNECTION_STRING);
        }

        public void Add(params CompanyJobSkillPoco[] items)
        {
            _dbHelper.Update("insert into company_job_skills(id, job, skill, skill_level, importance) values(@id, @job, @skill, @skill_level, @importance)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                    cmd.Parameters.Add(new SqlParameter("@skill", item.Skill));
                    cmd.Parameters.Add(new SqlParameter("@skill_level", item.SkillLevel));
                    cmd.Parameters.Add(new SqlParameter("@importance", item.Importance));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, job, skill, skill_level, importance, time_stamp from company_job_skills",
                reader =>
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
                });
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyJobSkillPoco)!;
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            _dbHelper.Update("delete from company_job_skills where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            _dbHelper.Update("update company_job_skills set job = @job, skill = @skill, skill_level = @skill_level, importance = @importance where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                    cmd.Parameters.Add(new SqlParameter("@skill", item.Skill));
                    cmd.Parameters.Add(new SqlParameter("@skill_level", item.SkillLevel));
                    cmd.Parameters.Add(new SqlParameter("@importance", item.Importance));
                }, items);
        }
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class ApplicantSkillRepository : ICrudRepository<ApplicantSkillPoco>
    {
        public void AddAll(ApplicantSkillPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantSkills.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public ApplicantSkillPoco FindOne(Expression<Func<ApplicantSkillPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.ApplicantSkills.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(ApplicantSkillPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantSkills.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(ApplicantSkillPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantSkills.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

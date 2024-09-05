using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyJobSkillRepository : ICrudRepository<CompanyJobSkillPoco>
    {
        public void AddAll(CompanyJobSkillPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobSkills.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyJobSkillPoco FindOne(Expression<Func<CompanyJobSkillPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyJobSkills.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyJobSkillPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobSkills.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyJobSkillPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobSkills.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

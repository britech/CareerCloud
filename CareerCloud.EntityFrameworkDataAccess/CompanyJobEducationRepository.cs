using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyJobEducationRepository : ICrudRepository<CompanyJobEducationPoco>
    {
        public void AddAll(CompanyJobEducationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobEducations.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyJobEducationPoco FindOne(Expression<Func<CompanyJobEducationPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyJobEducations.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyJobEducationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobEducations.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyJobEducationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobEducations.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

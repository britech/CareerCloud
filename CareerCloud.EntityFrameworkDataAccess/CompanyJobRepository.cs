using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyJobRepository : ICrudRepository<CompanyJobPoco>
    {
        public void AddAll(CompanyJobPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobs.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyJobPoco FindOne(Expression<Func<CompanyJobPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyJobs.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyJobPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobs.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyJobPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobs.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

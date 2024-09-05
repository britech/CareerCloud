using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyProfileRepository : ICrudRepository<CompanyProfilePoco>
    {
        public void AddAll(CompanyProfilePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyProfiles.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyProfilePoco FindOne(Expression<Func<CompanyProfilePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyProfiles.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyProfilePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyProfiles.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyProfilePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyProfiles.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

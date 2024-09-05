using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyLocationRepository : ICrudRepository<CompanyLocationPoco>
    {
        public void AddAll(CompanyLocationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyLocations.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyLocationPoco FindOne(Expression<Func<CompanyLocationPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyLocations.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyLocationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyLocations.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyLocationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyLocations.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

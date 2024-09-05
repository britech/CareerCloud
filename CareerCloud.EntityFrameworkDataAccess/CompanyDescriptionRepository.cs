using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyDescriptionRepository : ICrudRepository<CompanyDescriptionPoco>
    {
        public void AddAll(CompanyDescriptionPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyDescriptions.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyDescriptionPoco FindOne(Expression<Func<CompanyDescriptionPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyDescriptions.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyDescriptionPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyDescriptions.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyDescriptionPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyDescriptions.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

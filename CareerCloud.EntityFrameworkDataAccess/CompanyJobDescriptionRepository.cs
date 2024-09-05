using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CompanyJobDescriptionRepository : ICrudRepository<CompanyJobDescriptionPoco>
    {
        public void AddAll(CompanyJobDescriptionPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobDescriptions.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public CompanyJobDescriptionPoco FindOne(Expression<Func<CompanyJobDescriptionPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.CompanyJobDescriptions.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(CompanyJobDescriptionPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobDescriptions.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(CompanyJobDescriptionPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.CompanyJobDescriptions.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class SystemCountryCodeRepository : ICrudRepository<SystemCountryCodePoco>
    {
        public void AddAll(SystemCountryCodePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SystemCountryCodes.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public SystemCountryCodePoco FindOne(Expression<Func<SystemCountryCodePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.SystemCountryCodes.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(SystemCountryCodePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SystemCountryCodes.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(SystemCountryCodePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SystemCountryCodes.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

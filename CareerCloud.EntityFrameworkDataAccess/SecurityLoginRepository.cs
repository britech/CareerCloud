using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class SecurityLoginRepository : ICrudRepository<SecurityLoginPoco>
    {
        public void AddAll(SecurityLoginPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLogins.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public SecurityLoginPoco FindOne(Expression<Func<SecurityLoginPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.SecurityLogins.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(SecurityLoginPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLogins.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(SecurityLoginPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLogins.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class SecurityLoginsLogRepository : ICrudRepository<SecurityLoginsLogPoco>
    {
        public void AddAll(SecurityLoginsLogPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLoginsLogs.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public SecurityLoginsLogPoco FindOne(Expression<Func<SecurityLoginsLogPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.SecurityLoginsLogs.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(SecurityLoginsLogPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLoginsLogs.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(SecurityLoginsLogPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLoginsLogs.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

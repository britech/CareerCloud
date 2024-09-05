using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class SecurityRoleRepository : ICrudRepository<SecurityRolePoco>
    {
        public void AddAll(SecurityRolePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityRoles.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public SecurityRolePoco FindOne(Expression<Func<SecurityRolePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.SecurityRoles.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(SecurityRolePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityRoles.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(SecurityRolePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityRoles.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

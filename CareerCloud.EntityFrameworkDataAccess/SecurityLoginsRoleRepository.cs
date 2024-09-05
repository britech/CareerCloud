using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class SecurityLoginsRoleRepository : ICrudRepository<SecurityLoginsRolePoco>
    {
        public void AddAll(SecurityLoginsRolePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLoginsRoles.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public SecurityLoginsRolePoco FindOne(Expression<Func<SecurityLoginsRolePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.SecurityLoginsRoles.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(SecurityLoginsRolePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLoginsRoles.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(SecurityLoginsRolePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SecurityLoginsRoles.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class SystemLanguageCodeRepository : ICrudRepository<SystemLanguageCodePoco>
    {
        public void AddAll(SystemLanguageCodePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SystemLanguageCodes.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public SystemLanguageCodePoco FindOne(Expression<Func<SystemLanguageCodePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.SystemLanguageCodes.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(SystemLanguageCodePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SystemLanguageCodes.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(SystemLanguageCodePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.SystemLanguageCodes.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

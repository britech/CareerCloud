using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class ApplicantProfileRepository : ICrudRepository<ApplicantProfilePoco>
    {
        public void AddAll(ApplicantProfilePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantProfiles.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public ApplicantProfilePoco FindOne(Expression<Func<ApplicantProfilePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.ApplicantProfiles.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(ApplicantProfilePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantProfiles.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(ApplicantProfilePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantProfiles.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

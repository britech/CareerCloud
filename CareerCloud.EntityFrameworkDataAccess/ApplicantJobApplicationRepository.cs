using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class ApplicantJobApplicationRepository : ICrudRepository<ApplicantJobApplicationPoco>
    {
        public void AddAll(ApplicantJobApplicationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantJobApplications.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public ApplicantJobApplicationPoco FindOne(Expression<Func<ApplicantJobApplicationPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.ApplicantJobApplications.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(ApplicantJobApplicationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantJobApplications.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(ApplicantJobApplicationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantJobApplications.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

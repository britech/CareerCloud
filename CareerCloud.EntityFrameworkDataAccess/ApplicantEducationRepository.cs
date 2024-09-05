using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class ApplicantEducationRepository : ICrudRepository<ApplicantEducationPoco>
    {
        public void AddAll(ApplicantEducationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantEducations.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public ApplicantEducationPoco FindOne(Expression<Func<ApplicantEducationPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.ApplicantEducations.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(ApplicantEducationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantEducations.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(ApplicantEducationPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantEducations.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

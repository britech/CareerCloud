using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class ApplicantResumeRepository : ICrudRepository<ApplicantResumePoco>
    {
        public void AddAll(ApplicantResumePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantResumes.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public ApplicantResumePoco FindOne(Expression<Func<ApplicantResumePoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.ApplicantResumes.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(ApplicantResumePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantResumes.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(ApplicantResumePoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantResumes.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

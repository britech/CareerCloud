using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class ApplicantWorkHistoryRepository : ICrudRepository<ApplicantWorkHistoryPoco>
    {
        public void AddAll(ApplicantWorkHistoryPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantWorkHistories.AddRange(items);
                ctx.SaveChanges();
            }
        }

        public ApplicantWorkHistoryPoco FindOne(Expression<Func<ApplicantWorkHistoryPoco, bool>> expression)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                return ctx.ApplicantWorkHistories.Where(expression).FirstOrDefault()!;
            }
        }

        public void RemoveAll(ApplicantWorkHistoryPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantWorkHistories.RemoveRange(items);
                ctx.SaveChanges();
            }
        }

        public void UpdateAll(ApplicantWorkHistoryPoco[] items)
        {
            using (CareerCloudContext ctx = new CareerCloudContext())
            {
                ctx.ApplicantWorkHistories.UpdateRange(items);
                ctx.SaveChanges();
            }
        }
    }
}

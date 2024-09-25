using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantWorkHistoryRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<ApplicantWorkHistoryPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(ApplicantWorkHistoryPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantWorkHistories.AddRange(items);
        ctx.SaveChanges();
    }

    public ApplicantWorkHistoryPoco FindOne(Expression<Func<ApplicantWorkHistoryPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantWorkHistories.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(ApplicantWorkHistoryPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantWorkHistories.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(ApplicantWorkHistoryPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantWorkHistories.UpdateRange(items);
        ctx.SaveChanges();
    }
}

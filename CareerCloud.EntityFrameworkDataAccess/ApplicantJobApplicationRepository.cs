using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantJobApplicationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<ApplicantJobApplicationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(ApplicantJobApplicationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantJobApplications.AddRange(items);
        ctx.SaveChanges();
    }

    public ApplicantJobApplicationPoco FindOne(Expression<Func<ApplicantJobApplicationPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantJobApplications.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(ApplicantJobApplicationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantJobApplications.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(ApplicantJobApplicationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantJobApplications.UpdateRange(items);
        ctx.SaveChanges();
    }
}

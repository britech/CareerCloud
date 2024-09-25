using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantProfileRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<ApplicantProfilePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(ApplicantProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantProfiles.AddRange(items);
        ctx.SaveChanges();
    }

    public ApplicantProfilePoco FindOne(Expression<Func<ApplicantProfilePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantProfiles.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(ApplicantProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantProfiles.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(ApplicantProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantProfiles.UpdateRange(items);
        ctx.SaveChanges();
    }
}

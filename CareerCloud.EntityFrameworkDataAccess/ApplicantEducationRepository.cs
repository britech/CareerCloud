using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantEducationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<ApplicantEducationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(ApplicantEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantEducations.AddRange(items);
        ctx.SaveChanges();
    }

    public ApplicantEducationPoco FindOne(Expression<Func<ApplicantEducationPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantEducations.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(ApplicantEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantEducations.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(ApplicantEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantEducations.UpdateRange(items);
        ctx.SaveChanges();
    }
}

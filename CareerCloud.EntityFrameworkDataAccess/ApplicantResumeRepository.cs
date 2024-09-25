using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantResumeRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<ApplicantResumePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(ApplicantResumePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantResumes.AddRange(items);
        ctx.SaveChanges();
    }

    public ApplicantResumePoco FindOne(Expression<Func<ApplicantResumePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantResumes.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(ApplicantResumePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantResumes.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(ApplicantResumePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantResumes.UpdateRange(items);
        ctx.SaveChanges();
    }
}

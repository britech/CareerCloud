using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyJobRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<CompanyJobPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(CompanyJobPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobs.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyJobPoco FindOne(Expression<Func<CompanyJobPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobs.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyJobPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobs.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyJobPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobs.UpdateRange(items);
        ctx.SaveChanges();
    }
}

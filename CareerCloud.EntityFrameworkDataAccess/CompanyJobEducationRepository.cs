using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyJobEducationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<CompanyJobEducationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(CompanyJobEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobEducations.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyJobEducationPoco FindOne(Expression<Func<CompanyJobEducationPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobEducations.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyJobEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobEducations.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyJobEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobEducations.UpdateRange(items);
        ctx.SaveChanges();
    }
}

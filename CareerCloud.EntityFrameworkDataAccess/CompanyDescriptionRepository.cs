using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyDescriptionRepository(IDbContextFactory<CareerCloudContext> contextFactory) : ICrudRepository<CompanyDescriptionPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = contextFactory;

    public void AddAll(CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyDescriptions.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyDescriptionPoco FindOne(Expression<Func<CompanyDescriptionPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyDescriptions.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyDescriptions.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyDescriptions.UpdateRange(items);
        ctx.SaveChanges();
    }
}

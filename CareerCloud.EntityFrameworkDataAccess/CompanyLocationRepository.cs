using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyLocationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<CompanyLocationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(CompanyLocationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyLocations.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyLocationPoco FindOne(Expression<Func<CompanyLocationPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyLocations.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyLocationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyLocations.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyLocationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyLocations.UpdateRange(items);
        ctx.SaveChanges();
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyProfileRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<CompanyProfilePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(CompanyProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyProfiles.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyProfilePoco FindOne(Expression<Func<CompanyProfilePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyProfiles.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyProfiles.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyProfiles.UpdateRange(items);
        ctx.SaveChanges();
    }
}

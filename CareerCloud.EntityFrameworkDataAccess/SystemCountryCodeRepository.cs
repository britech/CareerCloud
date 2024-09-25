using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SystemCountryCodeRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<SystemCountryCodePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(SystemCountryCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemCountryCodes.AddRange(items);
        ctx.SaveChanges();
    }

    public SystemCountryCodePoco FindOne(Expression<Func<SystemCountryCodePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SystemCountryCodes.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(SystemCountryCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemCountryCodes.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(SystemCountryCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemCountryCodes.UpdateRange(items);
        ctx.SaveChanges();
    }
}

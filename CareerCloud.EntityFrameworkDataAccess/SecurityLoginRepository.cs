using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SecurityLoginRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<SecurityLoginPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLogins.AddRange(items);
        ctx.SaveChanges();
    }

    public SecurityLoginPoco FindOne(Expression<Func<SecurityLoginPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLogins.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLogins.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLogins.UpdateRange(items);
        ctx.SaveChanges();
    }
}

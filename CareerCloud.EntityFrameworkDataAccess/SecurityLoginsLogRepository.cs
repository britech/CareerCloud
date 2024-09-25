using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SecurityLoginsLogRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<SecurityLoginsLogPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(SecurityLoginsLogPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsLogs.AddRange(items);
        ctx.SaveChanges();
    }

    public SecurityLoginsLogPoco FindOne(Expression<Func<SecurityLoginsLogPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLoginsLogs.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(SecurityLoginsLogPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsLogs.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(SecurityLoginsLogPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsLogs.UpdateRange(items);
        ctx.SaveChanges();
    }
}

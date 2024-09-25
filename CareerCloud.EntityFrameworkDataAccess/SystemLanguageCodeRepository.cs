using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SystemLanguageCodeRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<SystemLanguageCodePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(SystemLanguageCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemLanguageCodes.AddRange(items);
        ctx.SaveChanges();
    }

    public SystemLanguageCodePoco FindOne(Expression<Func<SystemLanguageCodePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SystemLanguageCodes.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(SystemLanguageCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemLanguageCodes.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(SystemLanguageCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemLanguageCodes.UpdateRange(items);
        ctx.SaveChanges();
    }
}

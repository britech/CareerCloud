using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SystemLanguageCodeRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<SystemLanguageCodePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params SystemLanguageCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SystemLanguageCodes.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SystemLanguageCodes.ToList();
    }

    public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SystemLanguageCodes.Where(where).FirstOrDefault()!;
    }

    public void Remove(params SystemLanguageCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (SystemLanguageCodePoco item in items)
        {
            ctx.SystemLanguageCodes.Remove(GetSingle(e => e.LanguageID == item.LanguageID));
        }
        ctx.SaveChanges();
    }

    public void Update(params SystemLanguageCodePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (SystemLanguageCodePoco item in items)
        {
            SystemLanguageCodePoco row = GetSingle(e => e.LanguageID == item.LanguageID);
            row.Name = item.Name;
            row.NativeName = item.NativeName;
        }
        ctx.SaveChanges();
    }
}

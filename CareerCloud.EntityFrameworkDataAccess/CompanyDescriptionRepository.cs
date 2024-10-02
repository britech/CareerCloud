using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyDescriptionRepository(IDbContextFactory<CareerCloudContext> contextFactory) : IDataRepository<CompanyDescriptionPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = contextFactory;

    public void Add(params CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyDescriptions.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyDescriptions.ToList();
    }

    public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyDescriptions.Where(where).FirstOrDefault()!;
    }

    public void Remove(params CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyDescriptions.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void Update(params CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyDescriptions.UpdateRange(items);
        ctx.SaveChanges();
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess.Exceptions;
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
        foreach (CompanyDescriptionPoco item in items)
        {
            CompanyDescriptionPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(CompanyDescriptionPoco), item.Id);
            ctx.CompanyDescriptions.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params CompanyDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (CompanyDescriptionPoco item in items)
        {
            CompanyDescriptionPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(CompanyDescriptionPoco), item.Id);
            row.CompanyName = item.CompanyName;
            row.CompanyDescription = item.CompanyDescription;
            row.LanguageId = item.LanguageId;
            ctx.CompanyDescriptions.Update(row);
        }
        ctx.SaveChanges();
    }
}

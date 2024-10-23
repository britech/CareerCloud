using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess.Exceptions;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyJobEducationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<CompanyJobEducationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params CompanyJobEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobEducations.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobEducations.ToList();
    }

    public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobEducations.Where(where).FirstOrDefault()!;
    }

    public void Remove(params CompanyJobEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (CompanyJobEducationPoco item in items)
        {
            CompanyJobEducationPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(CompanyJobEducationPoco), item.Id);
            ctx.CompanyJobEducations.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params CompanyJobEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (CompanyJobEducationPoco item in items)
        {
            CompanyJobEducationPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(CompanyJobEducationPoco), item.Id);
            row.Major = item.Major;
            row.Importance = item.Importance;
            ctx.CompanyJobEducations.Update(row);
        }
        ctx.SaveChanges();
    }
}

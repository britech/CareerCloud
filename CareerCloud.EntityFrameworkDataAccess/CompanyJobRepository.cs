using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess.Exceptions;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyJobRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<CompanyJobPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params CompanyJobPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobs.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobs.ToList();
    }

    public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobs.Where(where).FirstOrDefault()!;
    }

    public void Remove(params CompanyJobPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (CompanyJobPoco item in items)
        {
            CompanyJobPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(CompanyJobPoco), item.Id);
            ctx.CompanyJobs.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params CompanyJobPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (CompanyJobPoco item in items)
        {
            CompanyJobPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(CompanyJobPoco), item.Id);
            row.ProfileCreated = item.ProfileCreated;
            row.IsCompanyHidden = item.IsCompanyHidden;
            row.IsInactive = item.IsInactive;
            ctx.CompanyJobs.Update(row);
        }
        ctx.SaveChanges();
    }
}

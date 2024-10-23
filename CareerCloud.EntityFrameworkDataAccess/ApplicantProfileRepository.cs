using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess.Exceptions;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantProfileRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<ApplicantProfilePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params ApplicantProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantProfiles.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantProfiles.ToList();
    }

    public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantProfiles.Where(where).FirstOrDefault()!;
    }

    public void Remove(params ApplicantProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (ApplicantProfilePoco item in items)
        {
            ApplicantProfilePoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(ApplicantProfilePoco), item.Id);
            ctx.ApplicantProfiles.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params ApplicantProfilePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (ApplicantProfilePoco item in items) 
        {
            ApplicantProfilePoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(ApplicantProfilePoco), item.Id);
            row.CurrentSalary = item.CurrentSalary ?? row.CurrentSalary;
            row.CurrentRate = item.CurrentRate ?? row.CurrentRate;
            row.Currency = item.Currency ?? row.Currency;
            row.Street = item.Street ?? row.Street;
            row.City = item.City ?? row.City;
            row.Province = item.Province ?? row.Province;
            row.PostalCode  = item.PostalCode ?? row.PostalCode;
            row.Country = item.Country ?? row.Country;
            ctx.ApplicantProfiles.Update(row);
        }
        ctx.SaveChanges();
    }
}

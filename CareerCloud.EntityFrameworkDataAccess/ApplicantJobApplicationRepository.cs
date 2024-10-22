using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess.Exceptions;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantJobApplicationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<ApplicantJobApplicationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params ApplicantJobApplicationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantJobApplications.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantJobApplications.ToList();
    }

    public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantJobApplications.Where(where).FirstOrDefault()!;
    }

    public void Remove(params ApplicantJobApplicationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (ApplicantJobApplicationPoco item in items)
        {
            ApplicantJobApplicationPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(ApplicantJobApplicationPoco), item.Id);
            ctx.ApplicantJobApplications.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params ApplicantJobApplicationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (ApplicantJobApplicationPoco item in items)
        {
            ApplicantJobApplicationPoco row = GetSingle(e => e.Id == item.Id) ?? throw new EntityNotFoundException(nameof(ApplicantJobApplicationPoco), item.Id);
            row.Applicant = item.Applicant;
            row.Job = item.Job;
            row.ApplicationDate = item.ApplicationDate;
            ctx.ApplicantJobApplications.Update(row);
        }
        ctx.SaveChanges();
    }
}

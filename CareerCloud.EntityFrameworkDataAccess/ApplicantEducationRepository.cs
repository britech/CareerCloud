using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantEducationRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<ApplicantEducationPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params ApplicantEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.ApplicantEducations.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantEducations.ToList();
    }

    public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.ApplicantEducations.Where(where).FirstOrDefault()!;
    }

    public void Remove(params ApplicantEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (ApplicantEducationPoco item in items)
        {
            ApplicantEducationPoco row = GetSingle(e => e.Id == item.Id) ?? throw new Exception("Operation not allowed.");
            ctx.ApplicantEducations.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params ApplicantEducationPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (ApplicantEducationPoco item in items)
        {
            ApplicantEducationPoco row = GetSingle(e => e.Id == item.Id) ?? throw new Exception("Operation not allowed.");
            row.Applicant = item.Applicant;
            row.Major = item.Major;
            row.CertificateDiploma = item.CertificateDiploma ?? row.CertificateDiploma;
            row.StartDate = item.StartDate ?? row.StartDate;
            row.CompletionDate = item.CompletionDate ?? row.CompletionDate;
            row.CompletionPercent = item.CompletionPercent ?? row.CompletionPercent;
            ctx.ApplicantEducations.Update(row);
        }
        ctx.SaveChanges();
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyJobDescriptionRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<CompanyJobDescriptionPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(CompanyJobDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobDescriptions.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyJobDescriptionPoco FindOne(Expression<Func<CompanyJobDescriptionPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobDescriptions.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyJobDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobDescriptions.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyJobDescriptionPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobDescriptions.UpdateRange(items);
        ctx.SaveChanges();
    }
}

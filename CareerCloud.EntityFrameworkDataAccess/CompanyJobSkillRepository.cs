using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CompanyJobSkillRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<CompanyJobSkillPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(CompanyJobSkillPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobSkills.AddRange(items);
        ctx.SaveChanges();
    }

    public CompanyJobSkillPoco FindOne(Expression<Func<CompanyJobSkillPoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.CompanyJobSkills.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(CompanyJobSkillPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobSkills.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(CompanyJobSkillPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.CompanyJobSkills.UpdateRange(items);
        ctx.SaveChanges();
    }
}

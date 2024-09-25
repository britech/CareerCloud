using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class ApplicantSkillRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<ApplicantSkillPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(ApplicantSkillPoco[] items)
    {
        using (CareerCloudContext ctx = _dbContextFactory.CreateDbContext())
        {
            ctx.ApplicantSkills.AddRange(items);
            ctx.SaveChanges();
        }
    }

    public ApplicantSkillPoco FindOne(Expression<Func<ApplicantSkillPoco, bool>> expression)
    {
        using (CareerCloudContext ctx = _dbContextFactory.CreateDbContext())
        {
            return ctx.ApplicantSkills.Where(expression).FirstOrDefault()!;
        }
    }

    public void RemoveAll(ApplicantSkillPoco[] items)
    {
        using (CareerCloudContext ctx = _dbContextFactory.CreateDbContext())
        {
            ctx.ApplicantSkills.RemoveRange(items);
            ctx.SaveChanges();
        }
    }

    public void UpdateAll(ApplicantSkillPoco[] items)
    {
        using (CareerCloudContext ctx = _dbContextFactory.CreateDbContext())
        {
            ctx.ApplicantSkills.UpdateRange(items);
            ctx.SaveChanges();
        }
    }
}

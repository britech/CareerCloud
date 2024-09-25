using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SecurityRoleRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<SecurityRolePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(SecurityRolePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityRoles.AddRange(items);
        ctx.SaveChanges();
    }

    public SecurityRolePoco FindOne(Expression<Func<SecurityRolePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityRoles.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(SecurityRolePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityRoles.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(SecurityRolePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityRoles.UpdateRange(items);
        ctx.SaveChanges();
    }
}

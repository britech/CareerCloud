using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SecurityLoginsRoleRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : ICrudRepository<SecurityLoginsRolePoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void AddAll(SecurityLoginsRolePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsRoles.AddRange(items);
        ctx.SaveChanges();
    }

    public SecurityLoginsRolePoco FindOne(Expression<Func<SecurityLoginsRolePoco, bool>> expression)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLoginsRoles.Where(expression).FirstOrDefault()!;
    }

    public void RemoveAll(SecurityLoginsRolePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsRoles.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void UpdateAll(SecurityLoginsRolePoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsRoles.UpdateRange(items);
        ctx.SaveChanges();
    }
}

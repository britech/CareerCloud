using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SecurityLoginsLogRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<SecurityLoginsLogPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params SecurityLoginsLogPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLoginsLogs.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLoginsLogs.ToList();
    }

    public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLoginsLogs.Where(where).FirstOrDefault()!;
    }

    public void Remove(params SecurityLoginsLogPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (SecurityLoginsLogPoco item in items)
        {
            SecurityLoginsLogPoco row = GetSingle(e => e.Id == item.Id) ?? throw new Exception("Operation not allowed.");
            ctx.SecurityLoginsLogs.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params SecurityLoginsLogPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (SecurityLoginsLogPoco item in items)
        {
            SecurityLoginsLogPoco row = GetSingle(e => e.Id == item.Id) ?? throw new Exception("Operation not allowed.");
            row.Login = item.Login;
            row.SourceIP = item.SourceIP;
            row.IsSuccesful = item.IsSuccesful;
            row.LogonDate = item.LogonDate;
            ctx.SecurityLoginsLogs.Update(row);
        }
        ctx.SaveChanges();
    }
}

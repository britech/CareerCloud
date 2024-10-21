using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class SecurityLoginRepository(IDbContextFactory<CareerCloudContext> dbContextFactory) : IDataRepository<SecurityLoginPoco>
{
    private readonly IDbContextFactory<CareerCloudContext> _dbContextFactory = dbContextFactory;

    public void Add(params SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLogins.AddRange(items);
        ctx.SaveChanges();
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLogins.ToList();
    }

    public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        return ctx.SecurityLogins.Where(where).FirstOrDefault()!;
    }

    public void Remove(params SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        ctx.SecurityLogins.RemoveRange(items);
        ctx.SaveChanges();
    }

    public void Update(params SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (SecurityLoginPoco item in items)
        {
            SecurityLoginPoco result = ctx.SecurityLogins.Single(e => e.Id == item.Id);
            result.Login = item.Login;
            result.Password = item.Password;
            result.PasswordUpdate = item.PasswordUpdate ?? result.PasswordUpdate;
            result.AgreementAccepted = item.AgreementAccepted ?? result.AgreementAccepted;
            result.IsLocked = item.IsLocked;
            result.IsInactive = item.IsInactive;
            result.EmailAddress = item.EmailAddress ?? result.EmailAddress;
            result.PhoneNumber = item.PhoneNumber ?? result.PhoneNumber;
            result.FullName = item.FullName ?? result.FullName;
            result.PrefferredLanguage = item.PrefferredLanguage ?? result.PrefferredLanguage;
        }
        ctx.SaveChanges();
    }
}

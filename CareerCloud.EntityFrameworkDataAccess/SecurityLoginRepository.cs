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
        foreach (SecurityLoginPoco item in items)
        {
            SecurityLoginPoco row = GetSingle(e => e.Id == item.Id) ?? throw new Exception("Operation not allowed.");
            ctx.SecurityLogins.Remove(row);
        }
        ctx.SaveChanges();
    }

    public void Update(params SecurityLoginPoco[] items)
    {
        using CareerCloudContext ctx = _dbContextFactory.CreateDbContext();
        foreach (SecurityLoginPoco item in items)
        {
            SecurityLoginPoco row = GetSingle(e => e.Id == item.Id) ?? throw new Exception("Operation not allowed.");
            row.Login = item.Login;
            row.Password = item.Password;
            row.Created = item.Created;
            row.PasswordUpdate = item.PasswordUpdate ?? row.PasswordUpdate;
            row.AgreementAccepted = item.AgreementAccepted ?? row.AgreementAccepted;
            row.IsLocked = item.IsLocked;
            row.IsInactive = item.IsInactive;
            row.EmailAddress = item.EmailAddress ?? row.EmailAddress;
            row.PhoneNumber = item.PhoneNumber ?? row.PhoneNumber;
            row.FullName = item.FullName ?? row.FullName;
            row.ForceChangePassword = item.ForceChangePassword;
            row.PrefferredLanguage = item.PrefferredLanguage ?? row.PrefferredLanguage;
            ctx.SecurityLogins.Update(row);
        }
        ctx.SaveChanges();
    }
}

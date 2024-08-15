using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : BaseLogic<SecurityRolePoco>(repository)
{
    protected override void Verify(SecurityRolePoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            if (string.IsNullOrEmpty(poco?.Role))
            {
                return [ValidationException.SECURITY_ROLE_REQUIRED];
            }
            return null!;
        }, pocos);
    }

    public override void Add(SecurityRolePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityRolePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : BaseLogic<SecurityRolePoco>(repository)
{
    protected override void Verify(SecurityRolePoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<SecurityRolePoco>(
                poco => !string.IsNullOrEmpty(poco?.Role),
                ValidationException.SECURITY_ROLE_REQUIRED)
            ], pocos);
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

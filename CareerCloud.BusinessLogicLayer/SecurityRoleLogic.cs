using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : BaseLogic<SecurityRolePoco>(repository)
{
    protected override void Verify(SecurityRolePoco[] pocos)
    {
        throw new NotImplementedException();
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

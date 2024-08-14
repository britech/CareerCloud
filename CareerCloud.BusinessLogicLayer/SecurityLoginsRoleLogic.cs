using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : BaseLogic<SecurityLoginsRolePoco>(repository)
{
    protected override void Verify(SecurityLoginsRolePoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(SecurityLoginsRolePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityLoginsRolePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

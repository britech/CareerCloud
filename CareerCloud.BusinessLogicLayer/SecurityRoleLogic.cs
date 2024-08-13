using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityRoleLogic : BaseLogic<SecurityRolePoco>
{
    public SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : base(repository)
    {
    }

    protected override void Verify(SecurityRolePoco item, List<ValidationException> validationErrors)
    {
        
    }
}

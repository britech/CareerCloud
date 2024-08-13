using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsLogLogic : BaseLogic<SecurityLoginsLogPoco>
{
    public SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : base(repository)
    {
    }

    protected override void Verify(SecurityLoginsLogPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}

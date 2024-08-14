using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : BaseLogic<SecurityLoginsLogPoco>(repository)
{
    protected override void Verify(SecurityLoginsLogPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(SecurityLoginsLogPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityLoginsLogPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

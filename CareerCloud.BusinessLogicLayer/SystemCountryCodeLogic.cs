using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SystemCountryCodeLogic : AbstractBaseLogic<SystemCountryCodePoco, string>
{
    public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) : base(repository)
    {
    }

    public override SystemCountryCodePoco Get(string id)
    {
        throw new NotImplementedException();
    }

    protected override void Verify(SystemCountryCodePoco[] items)
    {
        throw new NotImplementedException();
    }
}

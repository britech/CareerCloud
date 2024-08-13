using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SystemLanguageCodeLogic : AbstractBaseLogic<SystemLanguageCodePoco, string>
{
    public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) : base(repository)
    {
    }

    public override SystemLanguageCodePoco Get(string id)
    {
        throw new NotImplementedException();
    }

    protected override void Verify(SystemLanguageCodePoco[] items)
    {
        throw new NotImplementedException();
    }
}

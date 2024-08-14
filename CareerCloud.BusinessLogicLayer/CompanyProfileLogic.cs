using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : BaseLogic<CompanyProfilePoco>(repository)
{
    protected override void Verify(CompanyProfilePoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

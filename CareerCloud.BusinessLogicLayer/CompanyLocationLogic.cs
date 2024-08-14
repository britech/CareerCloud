using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : BaseLogic<CompanyLocationPoco>(repository)
{
    protected override void Verify(CompanyLocationPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(CompanyLocationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyLocationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : BaseLogic<CompanyJobEducationPoco>(repository)
{
    protected override void Verify(CompanyJobEducationPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(CompanyJobEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : BaseLogic<CompanyJobPoco>(repository)
{
    protected override void Verify(CompanyJobPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(CompanyJobPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}

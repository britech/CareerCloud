using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
{
    public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyLocationPoco[] items)
    {
        throw new NotImplementedException();
    }
}

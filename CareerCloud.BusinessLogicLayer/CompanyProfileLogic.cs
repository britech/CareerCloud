using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
{
    public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyProfilePoco[] items)
    {
        throw new NotImplementedException();
    }
}

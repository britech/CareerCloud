using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
{
    public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyProfilePoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}

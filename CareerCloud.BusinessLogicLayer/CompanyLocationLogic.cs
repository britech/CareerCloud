using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
{
    public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyLocationPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}

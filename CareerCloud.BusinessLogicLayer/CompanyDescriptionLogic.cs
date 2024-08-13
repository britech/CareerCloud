using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
{
    public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyDescriptionPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}

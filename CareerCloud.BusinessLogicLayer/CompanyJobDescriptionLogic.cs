using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
{
    public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyJobDescriptionPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}

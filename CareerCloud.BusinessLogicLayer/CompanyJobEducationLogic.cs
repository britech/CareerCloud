using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
{
    public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyJobEducationPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}

using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
{
    public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantWorkHistoryPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}
